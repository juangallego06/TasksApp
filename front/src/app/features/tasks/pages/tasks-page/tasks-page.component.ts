import { Component, inject, signal } from '@angular/core';
import { TasksService } from '../../services/tasks.service';
import {
  Tasks,
  TaskStatus,
  TaskStatusDescription,
} from '../../interfaces/tasks.interface';
import { LoadingSpinnerComponent } from '../../../../shared/components/loading-spinner/loading-spinner.component';
import { AlertErrorComponent } from '../../../../shared/components/alert-error/alert-error.component';
import { FiltersStacksComponent } from '../../components/filters-stacks/filters-stacks.component';
import { ListTasksComponent } from '../../components/list-tasks/list-tasks.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-tasks-page',
  standalone: true,
  imports: [
    LoadingSpinnerComponent,
    AlertErrorComponent,
    FiltersStacksComponent,
    ListTasksComponent,
    RouterLink,
  ],
  templateUrl: './tasks-page.component.html',
  styleUrl: './tasks-page.component.css',
})
export class TasksPageComponent {
  tasksService = inject(TasksService);

  isLoading = signal(true);
  tasks = signal<Tasks[]>([]);
  errorMessage = signal<string | null>(null);
  errorMessageUpdateStatus = signal<string | null>(null);
  selectedStatus = signal<TaskStatus | undefined>(undefined);
  selectedStatusUpdate = signal<TaskStatusDescription | undefined>(undefined);
  selectedTask = signal<Tasks | null>(null);
  isUpdatingStatus = signal(false);
  successMessage = signal<string | null>(null);

  constructor() {
    this.loadTasks();
  }

  loadTasks() {
    this.isLoading.set(true);
    this.errorMessage.set(null);
    this.tasksService
      .getTasks(
        this.selectedStatus() !== undefined ? this.selectedStatus() : undefined,
      )
      .subscribe({
        next: (response) => {
          this.tasks.set(response.data);
        },
        error: () => {
          this.errorMessage.set('An error occurred while loading tasks.');
        },
        complete: () => {
          this.isLoading.set(false);
        },
      });
  }

  onStatusChange(event: Event) {
    const value = (event.target as HTMLSelectElement).value;

    this.selectedStatus.set(
      value === '' ? undefined : (Number(value) as TaskStatus),
    );

    this.loadTasks();
  }

  openStatusModal(task: Tasks) {
    this.selectedTask.set(task);
    this.selectedStatusUpdate.set(task.status);
    this.isUpdatingStatus.set(false);
    this.errorMessageUpdateStatus.set(null);

    const modal = document.getElementById(
      'update_status_modal',
    ) as HTMLDialogElement;

    modal.showModal();
  }

  closeStatusModal() {
    const modal = document.getElementById(
      'update_status_modal',
    ) as HTMLDialogElement;

    modal.close();
  }

  updateTaskStatus() {
    const task = this.selectedTask();
    const status = this.selectedStatusUpdate();

    if (!task || status === null) return;

    this.isUpdatingStatus.set(true);
    this.errorMessageUpdateStatus.set(null);
    this.successMessage.set(null);

    this.tasksService.updateTaskStatus(task.id, status!).subscribe({
      next: (response) => {
        this.successMessage.set(response.message);
        this.isUpdatingStatus.set(false);
        this.closeStatusModal();
        this.loadTasks();
        setTimeout(() => {
          this.successMessage.set(null);
        }, 3000);
      },
      error: (error) => {
        this.errorMessageUpdateStatus.set(
          error.error.message ?? 'An error occurred while updating status.',
        );
        this.isUpdatingStatus.set(false);
      },
    });
  }
}
