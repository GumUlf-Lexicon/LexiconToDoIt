using LexiconToDoIt.Data;
using LexiconToDoIt.Model;
using System;
using Xunit;

namespace LexiconToDoIt.Tests.Data
{
	public class TodoItemShould
	{
		private void ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems)
		{
			// Arrange

			// personId is set to -1 bc we don't know the real ID yet
			// The todos in todos will be replaced with new todos
			// with the correct ID set in the for-loop below.
			todos =	  new Todo[4];
			todos[0] = new Todo(-1, "A todo to do");
			todos[1] = new Todo(-1, "Another todo");
			todos[2] = new Todo(-1, "Yet an todo");
			todos[3] = new Todo(-1, "Enough with todos already!");

			todoItems = new TodoItems();
			todoItems.Clear();

			for(int i = 0; i < todos.Length; i++)
			{
				Todo todo = todos[i];
				todos[i] = todoItems.NewTodo(todo.Description);
			}
		}

		[Fact]
		public void HaveTheRightSize()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems);

			// Act
			int todoItemsSize = todoItems.Size();

			// Assert
			Assert.Equal(todos.Length, todoItemsSize);
		}

		[Fact]
		public void BeAbleToFindAllTodos()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems);

			// Act
			Todo[] sut = todoItems.FindAll();

			// Assert
			Assert.Equal(todos.Length, sut.Length);

			foreach(Todo todo in todos)
			{
				Assert.Contains(sut, sutTodo => sutTodo == todo);
			}
		}

		[Fact]
		public void BeAbleToFindTodoById()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems);

			foreach(Todo todo in todos)
			{
				// Act
				Todo sut = todoItems.FindById(todo.TodoId);

				// Assert
				Assert.Equal(todo, sut);
			}
		}

		[Fact]
		public void BeAbleToCreateNewTodo()
		{
			// Arrange
			string todoDescription = "I guess there are more todos to do ...";
			TodoItems todoItems = new TodoItems();

			// Act
			Todo sut = todoItems.NewTodo(todoDescription);

			// Assert
			Assert.Equal(sut.Description, todoDescription);
	
		}


		[Fact]
		public void BeAbleToGetCleared()
		{
			// Arrange
			ArrangeTodoItems(out _, out TodoItems todoItems);
			int todoItemsSizeBefore = todoItems.Size();

			// Act
			todoItems.Clear();

			// Assert
			Assert.True(todoItemsSizeBefore > 0);
			Assert.Equal(0, todoItems.Size());
		}
	}
}
