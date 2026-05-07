export interface TasksResponse {
  data: Tasks[];
  isSuccess: boolean;
  message: string;
  errors: null;
}

export interface Tasks {
  id: number;
  title: string;
  description: string;
  status: TaskStatusDescription;
  userId: number;
  userName: string;
  createdAt: Date;
  metadataJson: string;
}

export enum TaskStatus {
  Pending = 0,
  InProgress = 1,
  Done = 2,
}

export enum TaskStatusDescription {
  Pending = 'Pending',
  InProgress = 'InProgress',
  Done = 'Done',
}

export interface TaskCreate {
  title: string;
  description: string;
  userId: number;
  metadataJson: string;
}

export interface TaskResponse {
  data: boolean;
  isSuccess: boolean;
  message: string;
  errors: null;
}
