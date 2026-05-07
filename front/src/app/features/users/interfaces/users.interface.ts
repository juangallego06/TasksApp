export interface UsersResponse {
  data: Users[];
  isSuccess: boolean;
  message: string;
  errors: null;
}

export interface Users {
  id: number;
  userName: string;
  email: string;
  createdAt: Date;
}

export interface UserResponse {
  data: User;
  isSuccess: boolean;
  message: string;
  errors: null;
}

export interface User {
  id: number;
  userName: string;
  email: string;
  createdAt: Date;
}

export interface UserCreate {
  userName: string;
  email: string;
}
