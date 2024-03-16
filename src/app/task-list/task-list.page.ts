import { Component, OnInit } from '@angular/core';
import { Tasks } from 'src/app/models/tasks';
import { TasksService } from 'src/app/services/tasks.service';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.page.html',
  styleUrls: ['./task-list.page.scss'],
})
export class TaskListPage implements OnInit {
  
  completedTaskList: Tasks[] = [];
  uncompletedTaskList: Tasks[] = [];
  
  constructor(private TaskService: TasksService, private alertController: AlertController) { }

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks() {
    this.TaskService.getAllTasks().subscribe(tasks => {
      this.completedTaskList = tasks.filter(task => task.completion === true);
      this.uncompletedTaskList = tasks.filter(task => task.completion === false);
    });
  }

  changeTaskCompletionToFalse(task: Tasks) {
    task.completion = false;
    this.TaskService.updateTask(task).subscribe(() => {
      this.loadTasks();
    });
  }
  changeTaskCompletionToTrue(task: Tasks) {
    task.completion = true;
    this.TaskService.updateTask(task).subscribe(() => {
      this.loadTasks();
    });
  }

  async addTask() {
    const alert = await this.alertController.create({
      header: 'Add Task',
      inputs: [
        {
          name: 'taskName',
          type: 'text',
          placeholder: 'Enter task name...'
        }
      ],
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel'
        },
        {
          text: 'Submit',
          handler: (data) => {
            if (data.taskName.trim() !== '') {
              this.TaskService.createTask({ taskName: data.taskName })
                .subscribe(() => {
                  this.loadTasks();
                });
            }
          }
        }
      ]
    });

    await alert.present();
  }

  deleteTask(taskId: string | undefined) {
    this.TaskService.deleteTask(taskId).subscribe(() => {
      this.loadTasks();
    });
  }
}
