import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import {
  UserCreate,
  UserResponse,
  UsersResponse,
} from '../interfaces/users.interface';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private http = inject(HttpClient);

  getUsers(): Observable<UsersResponse> {
    return this.http.get<UsersResponse>(`${baseUrl}/Users`);
  }

  addUser(userLike: UserCreate): Observable<UserResponse> {
    return this.http.post<UserResponse>(`${baseUrl}/Users`, userLike);
  }
}
