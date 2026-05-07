import { Component, inject, OnInit, signal } from '@angular/core';
import { AlertErrorComponent } from '../../../../shared/components/alert-error/alert-error.component';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TasksService } from '../../services/tasks.service';
import { Router, RouterLink } from '@angular/router';
import { Users } from '../../../users/interfaces/users.interface';
import { UsersService } from '../../../users/services/users.service';
import { SelectUsersComponent } from '../../../users/components/select-users/select-users.component';
import { TaskCreate } from '../../interfaces/tasks.interface';

@Component({
  selector: 'app-new-task-page',
  standalone: true,
  imports: [
    AlertErrorComponent,
    ReactiveFormsModule,
    SelectUsersComponent,
    RouterLink,
  ],
  templateUrl: './new-task-page.component.html',
  styleUrl: './new-task-page.component.css',
})
export class NewTaskPageComponent implements OnInit {
  fb = inject(FormBuilder);
  tasksService = inject(TasksService);
  usersService = inject(UsersService);
  router = inject(Router);

  isSubmitting = signal(false);
  apiErrorMessage = signal('');
  users = signal<Users[]>([]);

  taskForm = this.fb.nonNullable.group({
    title: ['', [Validators.required, Validators.maxLength(200)]],
    description: ['', [Validators.maxLength(250)]],
    userId: [0, [Validators.required, Validators.min(1)]],
    priority: ['Medium'],
    tags: [''],
    estimatedDate: [''],
  });

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.usersService.getUsers().subscribe({
      next: (response) => {
        this.users.set(response.data);
      },
    });
  }

  async onSubmit() {
    const isValid = this.taskForm.valid;
    this.taskForm.markAllAsTouched();

    if (!isValid) return;

    const formValue = this.taskForm.getRawValue();

    const metadata = {
      priority: formValue.priority,
      estimatedDate: formValue.estimatedDate,
      tags: formValue.tags
        .split(',')
        .map((tag) => tag.trim())
        .filter(Boolean),
    };

    const payload: TaskCreate = {
      title: formValue.title,
      description: formValue.description,
      userId: formValue.userId,
      metadataJson: JSON.stringify(metadata),
    };

    this.tasksService.addTask(payload).subscribe({
      next: () => {
        this.router.navigate(['/tasks']);
      },
      error: (error) => {
        this.apiErrorMessage.set(
          error.error.message ?? 'An error occurred while creating the task.',
        );
      },
      complete: () => {
        this.isSubmitting.set(false);
      },
    });
  }
}
