using System;

namespace Lab02Tyshchenko.Model
{
    public class Storage
    {
        public event Action<Person> PersonChanged;

        public Person Person { get; private set; }

        public void ChangeInfo(Person person)
        {
            Person = person;
            PersonChanged?.Invoke(person);
        }
    }
}
