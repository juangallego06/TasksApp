import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import {
  TaskCreate,
  TaskResponse,
  TasksResponse,
  TaskStatus,
  TaskStatusDescription,
} from '../interfaces/tasks.interface';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  private http = inject(HttpClient);

  private statusMap: Record<TaskStatusDescription, number> = {
    [TaskStatusDescription.Pending]: 0,

    [TaskStatusDescription.InProgress]: 1,

    [TaskStatusDescription.Done]: 2,
  };

  getTasks(status?: TaskStatus): Observable<TasksResponse> {
    const url =
      status !== undefined ? `${baseUrl}/Tasks/${status}` : `${baseUrl}/Tasks`;

    return this.http.get<TasksResponse>(url);
  }

  addTask(taskLike: TaskCreate): Observable<TaskResponse> {
    return this.http.post<TaskResponse>(`${baseUrl}/Tasks`, taskLike);
  }

  updateTaskStatus(
    taskId: number,
    status: TaskStatusDescription,
  ): Observable<TaskResponse> {
    return this.http.put<TaskResponse>(`${baseUrl}/Tasks/${taskId}/status`, {
      status: this.statusMap[status],
    });
  }
}
