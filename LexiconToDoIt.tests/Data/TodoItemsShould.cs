using LexiconToDoIt.Data;
using LexiconToDoIt.Model;
using Xunit;

namespace LexiconToDoIt.Tests.Data
{
	public class TodoItemsShould
	{

		[Fact]
		public void HaveTheRightSize()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out _);

			// Act
			int todoItemsSize = todoItems.Size();

			// Assert
			Assert.Equal(todos.Length, todoItemsSize);
		}

		[Fact]
		public void BeAbleToFindAllTodos()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out _);

			// Act
			Todo[] sut = todoItems.FindAll();

			// Assert
			Assert.Equal(todos.Length, sut.Length);

			foreach(Todo todo in todos)
			{
				Assert.Contains(sut, sutTodo => sutTodo.Equals(todo));
			}
		}

		[Fact]
		public void BeAbleToFindTodoById()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out _);

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
			ArrangeTodoItems(out _, out TodoItems todoItems, out _);
			int todoItemsSizeBefore = todoItems.Size();

			// Act
			todoItems.Clear();

			// Assert
			Assert.True(todoItemsSizeBefore > 0);
			Assert.Equal(0, todoItems.Size());
		}

		[Fact]
		public void BeAbleToFindTodoByStatus()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out _);

			// Act
			Todo[] sutDoneItems = todoItems.FindByDoneStatus(true);
			Todo[] sutNotDoneItems = todoItems.FindByDoneStatus(false);

			// Assert
			foreach(Todo item in todos)
			{
				if(item.Done)
				{
					Assert.Contains(sutDoneItems, sutTodo => sutTodo.Equals(item));
					Assert.DoesNotContain(sutNotDoneItems, sutTodo => sutTodo.Equals(item));
				}
				else
				{
					Assert.Contains(sutNotDoneItems, sutTodo => sutTodo.Equals(item));
					Assert.DoesNotContain(sutDoneItems, sutTodo => sutTodo.Equals(item));
				}
			}

		}

		[Fact]
		public void BeAbleToFindTodoByAssigneeByPersonId()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out People people);
			Person[] persons = people.FindAll();

			foreach(Person person in persons)
			{
				// Act
				Todo[] sutTodosForPerson = todoItems.FindByAssignee(person.PersonId);

				// Assert
				foreach(Todo item in todos)
				{
					if(item.Assignee == person)
					{
						Assert.Contains(sutTodosForPerson, sutTodo => sutTodo.Assignee == person);
					}
				}
			}


		}

		[Fact]
		public void BeAbleToFindTodoByAssigneeByPerson()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out People people);

			Person[] persons = people.FindAll();

			foreach(Person person in persons)
			{
				// Act
				Todo[] sutTodosForPerson = todoItems.FindByAssignee(person);

				// Assert 
				foreach(Todo item in todos)
				{
					if(item.Assignee == person)
					{
						Assert.Contains(sutTodosForPerson, sutTodo => sutTodo.Assignee == person);
					}
				}
			}
		}

		[Fact]
		public void BeAbleToFindUnassignedTodo()
		{
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out People people);

			Todo[] isUnassigned = todoItems.FindUnassignedTodoItems();

			foreach(var item in todos)
			{
				if(item.Assignee is null)
				{
					Assert.Contains(isUnassigned, sutTodo => sutTodo.Equals(item));
				}
				else
				{
					Assert.DoesNotContain(isUnassigned, sutTodo => sutTodo.Equals(item));
				}
			}
		}

		[Fact]
		public void BeAbleToRemoveExistingItemByTodoObject()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out _);
			Todo todoItemToRemove = todos[todos.Length / 2];
			Todo[] sutBefore = todoItems.FindAll();

			// Act
			bool removeSuccess = todoItems.RemoveTodoItem(todoItemToRemove);
			Todo[] sut = todoItems.FindAll();

			// Assert
			Assert.True(todos.Length > 0);
			Assert.Contains(sutBefore, sutItem => sutItem.Equals(todoItemToRemove));
			Assert.True(removeSuccess);
			Assert.DoesNotContain(sut, sutItem => sutItem.Equals(todoItemToRemove));


		}

		[Fact]
		public void BeAbleToRemoveExistingItemByTodoId()
		{
			// Arrange
			ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out _);
			int todoItemIdToRemove = todos[todos.Length / 2].TodoId;
			Todo[] sutBefore = todoItems.FindAll();

			// Act
			bool removeSuccess = todoItems.RemoveTodoItem(todoItemIdToRemove);
			Todo[] sut = todoItems.FindAll();

			// Assert
			Assert.True(todos.Length > 0);
			Assert.Contains(sutBefore, sutItem => sutItem.TodoId == todoItemIdToRemove);
			Assert.True(removeSuccess);
			Assert.DoesNotContain(sut, sutItem => sutItem.TodoId == todoItemIdToRemove);
		}


		// To not have to repeat similar code in several of the tests
		private void ArrangeTodoItems(out Todo[] todos, out TodoItems todoItems, out People people)
		{
			// todos[] keeps track of expected todoItems
			// todoItems is the subject under testing
			// people cointains the persons that are used
			// (people is used by both todos[] and todoItems)

			// Arrange

			// personId is set to 0 or 1 because we don't know the real ID yet.
			// Now they are used to represent if the todo will be marked
			// as done or not in the for-loop below. 1 => true, 0 => false.
			// The todos in todos will be replaced with new todos
			// with the correct ID set in the for-loop below.
			todos = new Todo[8];
			todos[0] = new Todo(0, "A todo to do");
			todos[1] = new Todo(1, "Another todo");
			todos[2] = new Todo(1, "Yet an todo");
			todos[3] = new Todo(0, "Enough with todos already!");
			todos[4] = new Todo(1, "Alright, something more todo");
			todos[5] = new Todo(0, "Todo or not todo?");
			todos[6] = new Todo(0, "ToDoToDoToDoToDo");
			todos[7] = new Todo(1, "Too much to do!");

			// We need some people to help us with the tests
			people = new People();
			_ = people.NewPerson("Nomen", "Nescio"); // nomen nescio <=> N.N. <=> "I do not know the name."
			Person jane = people.NewPerson("Jane", "Doe");
			_ = people.NewPerson("Svea", "Svensson");
			Person john = people.NewPerson("John", "Doe");
			_ = people.NewPerson("Ole", "Normann");

			// We want to have som todo items to test
			todoItems = new TodoItems();
			todoItems.Clear();

			// todos are used to fill the new todoItems with data
			for(int i = 0; i < todos.Length; i++)
			{
				bool done = todos[i].TodoId == 1;

				Todo todo = todoItems.NewTodo(todos[i].Description);

				// To not have refereces to the todos in todoItems,
				// new Todos are created for the todos array.
				todos[i] = new Todo(todo.TodoId, todo.Description);

				todo.Done = done;
				todos[i].Done = done;
			}

			// We need to have some todos to have assignees but not all
			Todo[] allTodoItems = todoItems.FindAll();
			for(int i = 0; i < allTodoItems.Length; i++)
			{
				Todo item = allTodoItems[i];
				if(item.Done && item.TodoId % 2 == 0)
				{
					item.Assignee = jane;
					todos[i].Assignee = item.Assignee;
				}
				else if(item.Done)
				{
					item.Assignee = john;
					todos[i].Assignee = item.Assignee;
				}
			}
		}
	}
}
