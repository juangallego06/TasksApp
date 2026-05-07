import { Component, effect, inject, signal } from '@angular/core';
import { UsersService } from '../../services/users.service';
import { toSignal } from '@angular/core/rxjs-interop';
import { Users } from '../../interfaces/users.interface';
import { AlertErrorComponent } from '../../../../shared/components/alert-error/alert-error.component';
import { LoadingSpinnerComponent } from '../../../../shared/components/loading-spinner/loading-spinner.component';
import { ListUsersComponent } from '../../components/list-users/list-users.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-users-page',
  standalone: true,
  imports: [
    AlertErrorComponent,
    LoadingSpinnerComponent,
    ListUsersComponent,
    RouterLink,
  ],
  templateUrl: './users-page.component.html',
  styleUrl: './users-page.component.css',
})
export class UsersPageComponent {
  usersService = inject(UsersService);

  isLoading = signal(true);
  users = signal<Users[]>([]);
  errorMessage = signal<string | null>(null);

  constructor() {
    this.loadUsers();
  }

  loadUsers() {
    this.isLoading.set(true);
    this.errorMessage.set(null);
    this.usersService.getUsers().subscribe({
      next: (response) => {
        this.users.set(response.data);
      },
      error: () => {
        this.errorMessage.set('An error occurred while loading users.');
      },
      complete: () => {
        this.isLoading.set(false);
      },
    });
  }
}
