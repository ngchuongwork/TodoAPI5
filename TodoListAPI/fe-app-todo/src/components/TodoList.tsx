import React from 'react';
import { useState, useRef, useEffect } from "react";
import Task, { TaskProps } from './Task';
import { Status } from './Status';
import '../css/style.css';
import { GET_ALL_TODOs, DELETE_TODO_ID, POST_ADD_TODO, PUT_EDIT_TODO } from '../api/apiService';
import { AxiosResponse } from 'axios';


function TodoList() {
  const [inputValue, setInputValue] = useState('');
    const [tasks, setTasks] = useState<TaskProps[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await GET_ALL_TODOs('TodoList');
                const newTask: TaskProps[] = response.data;
                setTasks([...newTask]);
            } catch (error) {
                console.error('Error fetching todos:', error);
            }
        };

        fetchData();
    }, [/* Add dependencies here if needed, e.g., GET_ALL_TODOs */]);



  function handleChange(e: any) {
    setInputValue(e.target.value)
  }

  
  function handleSubmit(e: any) {
    e.preventDefault();
      const newTask: TaskProps = {
          id :0, 
          description: inputValue,
          status: Status.PENDING,
          datetime: new Date().toISOString(),
        };
      POST_ADD_TODO(`TodoList`, newTask).then(item => {
          const x =  (item as AxiosResponse<TaskProps>).data;
          newTask.id = x.id;
          setTasks([...tasks, newTask]);
          setInputValue("");

      });
  }

   // Hàm callback để cập nhật tasks
   const updateTasks = (updatedTask: TaskProps) => {
    setTasks((prevTasks) =>
      prevTasks.map((task) =>
        task.id === updatedTask.id ? updatedTask : task
      )
    );
    PUT_EDIT_TODO(`TodoList/${updatedTask.id}`, updatedTask);
  };

   // Hàm callback để delete tasks
   const deleteTasks = (updatedTask: TaskProps) => {
    var result = tasks.filter((task) => task.id != updatedTask.id);
    setTasks(result);
    DELETE_TODO_ID(`TodoList/${updatedTask.id}`);
  };

  return (
    <div className='todo-container'>
      <div className='todo-container-div'>
        <center>
          <h3>TodoList</h3>
        </center>
        <form className='todo-container-div-formInput'>
          <input style={{ width: "85%" }} type="text" value={inputValue} onChange={handleChange}/>
          <button style={{ width: "15%" }} onClick={handleSubmit}> Add</button>
        </form>
        <form>
          <ul className='todo-list'>
            {tasks.map((task) => task.status == 1 ? (
              <Task  key={task.id} task={task} updateTaskProp={updateTasks} deleteTaskProp={deleteTasks}/>
            ) : "")}
          </ul>
        </form>
      </div>
      <form className='todo-container-div'>
        <center>
          <h3>Done List</h3>
        </center>

        <ul  className='todo-list'>
          {tasks.map((task) => task.status == 2 ? (
            <Task  key={task.id} task={task} updateTaskProp={updateTasks} deleteTaskProp={deleteTasks} />
          ) : "")}

        </ul>
      </form>
    </div>
  );
}


export default TodoList;