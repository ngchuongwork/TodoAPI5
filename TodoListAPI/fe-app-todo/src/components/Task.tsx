import React from 'react';
import { Status } from './Status';
import { useState, useRef, useEffect } from "react";
import '../css/style.css';

export interface TaskProps {
    id: number;
    description: string;
    status: number; // Adjust the type according to your actual implementation
    datetime: string; // Adjust the type according to your actual implementation
}
interface TaskComponentProps {
    task: TaskProps;
    updateTaskProp: (updatedTask: TaskProps) => void;
    deleteTaskProp: (updatedTask: TaskProps) => void;
}

function Task({ task, updateTaskProp, deleteTaskProp }: TaskComponentProps) {
    function handleOutUpdate(e: any) {
        const updatedId = e.target.id;
    }
    
    function onTypingTask(e: any) {
        updateTaskProp({ ...task, description:e.target.value });
    }

    function doneTask(e: any) {
        const checked = e.target.checked;
        updateTaskProp({ ...task, status: checked ? Status.DONE : Status.PENDING });

    }
    function deleteTask(e:any){
        updateTaskProp({ ...task, status:  Status.DELETED  });
        deleteTaskProp(task);
    }

    return (
        <li>
            <input
                type="checkbox"
                checked={task.status == Status.PENDING ? false : true}
                onChange={doneTask}
            />
            <input
                type="text"
                id={task.id.toString()}
                onBlur={handleOutUpdate}
                onChange={onTypingTask}
                value={task.description}
                className={task.status == Status.PENDING ? 'todo-task' : 'done-task'}
            />
             <button value={task.id} type="button" onClick={deleteTask}>
                Delete
            </button>
        </li>
    );

}

export default Task;
