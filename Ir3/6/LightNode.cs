using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Flyweight
{
    // Базовий абстрактний клас для всіх вузлів
    public abstract class LightNode
    {
        public abstract string OuterHtml();
    }

    // Текстовий вузол 
    public class LightTextNode : LightNode
    {
        private string _text;
        public LightTextNode(string text) => _text = text;
        public override string OuterHtml() => _text;
    }


    // ПІДХІД 1: ВАЖКИЙ ВУЗОЛ (БЕЗ ЛЕГКОВАГОВИКА)
    public class HeavyElementNode : LightNode
    {
        public string TagName { get; set; }
        public bool IsBlock { get; set; }
        public bool IsSelfClosing { get; set; }

        private List<LightNode> _children = new List<LightNode>();

        public HeavyElementNode(string tagName, bool isBlock = true, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
        }

        public void AddChild(LightNode node) => _children.Add(node);

        public override string OuterHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{TagName}>");
            foreach (var child in _children) { sb.Append(child.OuterHtml()); }
            sb.Append($"</{TagName}>");
            return sb.ToString();
        }
    }


    // ПІДХІД 2: ЛЕГКОВАГОВИЙ ВУЗОЛ (FLYWEIGHT)

    public class FlyweightElementNode : LightNode
    {
        // Замість купи полів зберігаємо лише одне посилання на спільний об'єкт!
        private TagInfo _tagInfo;
        private List<LightNode> _children = new List<LightNode>();

        public FlyweightElementNode(TagInfo tagInfo)
        {
            _tagInfo = tagInfo;
        }

        public void AddChild(LightNode node) => _children.Add(node);

        public override string OuterHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{_tagInfo.Name}>");
            foreach (var child in _children) { sb.Append(child.OuterHtml()); }
            sb.Append($"</{_tagInfo.Name}>");
            return sb.ToString();
        }
    }
}