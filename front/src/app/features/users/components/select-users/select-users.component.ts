import { Component, input } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { Users } from '../../interfaces/users.interface';

@Component({
  selector: 'app-select-users',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './select-users.component.html',
})
export class SelectUsersComponent {
  users = input.required<Users[]>();
  control = input.required<FormControl>();
}
