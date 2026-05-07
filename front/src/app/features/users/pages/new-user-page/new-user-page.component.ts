import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsersService } from '../../services/users.service';
import { Router, RouterLink } from '@angular/router';
import { AlertErrorComponent } from '../../../../shared/components/alert-error/alert-error.component';

@Component({
  selector: 'app-new-user-page',
  standalone: true,
  imports: [ReactiveFormsModule, AlertErrorComponent, RouterLink],
  templateUrl: './new-user-page.component.html',
  styleUrl: './new-user-page.component.css',
})
export class NewUserPageComponent {
  fb = inject(FormBuilder);
  usersService = inject(UsersService);
  router = inject(Router);

  isSubmitting = signal(false);
  apiErrorMessage = signal('');

  userForm = this.fb.nonNullable.group({
    userName: ['', [Validators.required, Validators.maxLength(100)]],
    email: [
      '',
      [Validators.required, Validators.email, Validators.maxLength(100)],
    ],
  });

  async onSubmit() {
    const isValid = this.userForm.valid;
    this.userForm.markAllAsTouched();

    if (!isValid) return;

    this.usersService.addUser(this.userForm.getRawValue()).subscribe({
      next: () => {
        this.router.navigate(['/users']);
      },
      error: (error) => {
        this.apiErrorMessage.set(
          error.error.message ?? 'An error occurred while creating the user.',
        );
      },
      complete: () => {
        this.isSubmitting.set(false);
      },
    });
  }
}
