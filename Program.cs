using _11_03_2023_Task1;

Person p = new Person("Vlad", "Berestiuk", DateTime.Now, "top");
var path = "D:\\persons.txt";
var personService = new PersonService(path);
var personController = new PersonController(personService);

while (true)
{
	Console.WriteLine("Choose an action");
	Console.WriteLine("1 - Add person");
	Console.WriteLine("2 - List persons");
	Console.WriteLine("3 - Exit");

	var choice = Console.ReadLine();
	switch (choice)
	{
		case "1":
			personController.AddPerson();
			break;
		case "2":
			personController.ListPersons();
			break;
		default:
			Console.WriteLine("Invalid");
			break;
	}
}


public interface IPersonService
{
	void SavePerson(Person person);
	Person[] LoadPerson();
}

public class PersonController
{
	private readonly IPersonService _personService;
	public PersonController(IPersonService personService)
	{
		_personService = personService;
	}

	public void AddPerson()
	{
		Console.Write("Enter first name: ");
		var firstname = Console.ReadLine();
		Console.Write("Enter last name: ");
		var lastname = Console.ReadLine();
		Console.Write("Enter date of birth: ");
		var dob = DateTime.Parse(Console.ReadLine());
		Console.Write("Enter other information: ");
		var info = Console.ReadLine();
		var person = new Person(
			firstname, 
			lastname,
			dob,
			info
			);
		_personService.SavePerson( person );
		Console.WriteLine("Person saved");
	}

	public void ListPersons()
	{
		var persons = _personService.LoadPerson();
        foreach (var item in persons)
        {
			Console.WriteLine($"{item.Name}, {item.LastName}, {item.DoB}, {item.Info}");
        }
    }
}

public class PersonService : IPersonService
{
	private readonly string _filePath;
	public PersonService(string filePath)
	{
		_filePath = filePath;
	}
	public Person[] LoadPerson()
	{
		var persons = new Person[0];
		if (!File.Exists(_filePath))
			return persons;
		using var reader = new StreamReader(_filePath);
		while(!reader.EndOfStream)
		{
			var line = reader.ReadLine();
			var parts = line.Split(',');
			if(parts.Length != 4) continue;
			var person = new Person(
				parts[0],
				parts[1],
				DateTime.Parse(parts[2]),
				parts[3]
				);
			Array.Resize(ref persons, persons.Length + 1);
			persons[^1] = person;
		}
		return persons;
	}

	public void SavePerson(Person person)
	{
		using var writer = new StreamWriter(_filePath, true);
		writer.WriteLine($"{person.Name}, {person.LastName}, {person.DoB}, {person.Info}");
	}
}





