using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Prototype
{
    public interface IClassicPrototype
    {
        IClassicPrototype Clone();
    }

    public class Virus : IClassicPrototype
    {
        private string _name;
        private double _weight;
        private int _age;
        private string _type;
        private List<Virus> _children;

        public Virus(string name, double weight, int age, string type)
        {
            this._name = name;
            this._weight = weight;
            this._age = age;
            this._type = type;
            this._children = new List<Virus>();
        }

        // Конструктор копіювання для клонування
        public Virus(Virus prototype)
        {
            this._name = prototype._name;
            this._weight = prototype._weight;
            this._age = prototype._age;
            this._type = prototype._type;
            
            //копіювання списку дітей: кожен нащадок клонується окремо
            this._children = prototype._children
                .Select(child => (Virus)child.Clone())
                .ToList();
        }

        public IClassicPrototype Clone()
        {
            // Створення нового об'єкта через конструктор копіювання
            return new Virus(this);
        }

        public void AddChild(Virus child)
        {
            _children.Add(child);
        }

        public void SetName(string name) => _name = name;

        public override string ToString()
        {
            string childrenInfo = _children.Count > 0 
                ? $" (Дітей: {_children.Count} -> [{string.Join(", ", _children.Select(c => c._name))}])" 
                : " (Немає дітей)";
            
            return $"Вірус: {_name}, Тип: {_type}, Вага: {_weight}, Вік: {_age}{childrenInfo}";
        }
    }
}