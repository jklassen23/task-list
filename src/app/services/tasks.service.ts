import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tasks } from '../models/tasks';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
  baseURL: string = "http://localhost:5076/Task";

  constructor(private http: HttpClient) { }

  getAllTasks(): Observable<Tasks[]> {
    return this.http.get<Tasks[]>(this.baseURL);
  }

  getTask(taskId: string) {
    return this.http.get<Tasks>(`${this.baseURL}/${taskId}`);
  }

  createTask(newTask: Tasks) {
    return this.http.post(this.baseURL, newTask);
  } 

  updateTask(updatedTask: Tasks) {
    return this.http.put(`${this.baseURL}/${updatedTask.taskId}`, updatedTask);
  }

  deleteTask(taskId: string | undefined) {
    return this.http.delete(`${this.baseURL}/${taskId}`)
  }
}
