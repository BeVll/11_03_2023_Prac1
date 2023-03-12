using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_03_2023_Task1
{
	public class Person
	{
		//public IPersonDataWriter PersonDataWriter;
		public string Name { get; set; }
		public string LastName { get; set; }
		public DateTime DoB { get; set; }
		public string Info { get; set; }

		public Person(string name, string lastname, DateTime date, string info) { 
			this.Name = name;
			this.LastName = lastname;
			this.DoB = date;
			this.Info = info;
		}
		//public void Show()
		//{
		//	this.PersonDataWriter.write(this);
		//}
	}
}
