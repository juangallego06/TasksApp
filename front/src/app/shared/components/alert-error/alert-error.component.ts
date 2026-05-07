import { Component, input } from '@angular/core';

@Component({
  selector: 'app-alert-error',
  standalone: true,
  imports: [],
  templateUrl: './alert-error.component.html',
  styleUrl: './alert-error.component.css',
})
export class AlertErrorComponent {
  errorMessage = input.required<string>();
}
