import { Component, input, output } from '@angular/core';
import { Tasks } from '../../interfaces/tasks.interface';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-list-tasks',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './list-tasks.component.html',
  styleUrl: './list-tasks.component.css',
})
export class ListTasksComponent {
  tasks = input.required<Tasks[]>();
  openModal = output<Tasks>();
}
