export class Tasks {
    taskId?: string;
    taskName?: string;
    completion?: boolean;
  
    constructor(taskId?: string, taskName?: string, completion?: boolean) {
      this.taskId = taskId;
      this.taskName = taskName;
      this.completion = completion;
    }
}
