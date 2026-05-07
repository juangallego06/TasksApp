import { Component, input } from '@angular/core';
import { Users } from '../../interfaces/users.interface';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-list-users',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './list-users.component.html',
  styleUrl: './list-users.component.css',
})
export class ListUsersComponent {
  users = input.required<Users[]>();
}
