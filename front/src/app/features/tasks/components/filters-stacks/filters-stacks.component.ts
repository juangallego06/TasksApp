import { Component, input, output, signal } from '@angular/core';
import { TaskStatus } from '../../interfaces/tasks.interface';

@Component({
  selector: 'app-filters-stacks',
  standalone: true,
  imports: [],
  templateUrl: './filters-stacks.component.html',
  styleUrl: './filters-stacks.component.css',
})
export class FiltersStacksComponent {
  selectedStatus = input.required<TaskStatus>();
  newStatus = output<Event>();
}
