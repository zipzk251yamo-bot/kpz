using System.Collections.Generic;

namespace DesignPatterns.Flyweight
{
    // ¬нутр≥шн≥й стан (те, що повторюЇтьс€ тис€ч≥ раз≥в)
    public class TagInfo
    {
        public string Name { get; }
        public bool IsBlock { get; }
        public bool IsSelfClosing { get; }

        public TagInfo(string name, bool isBlock, bool isSelfClosing = false)
        {
            Name = name;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
        }
    }

    // ‘абрика дл€ управл≥нн€ пулом об'Їкт≥в
    public static class TagFactory
    {
        private static Dictionary<string, TagInfo> _tagsPool = new Dictionary<string, TagInfo>();

        public static TagInfo GetTag(string tagName)
        {
            if (!_tagsPool.ContainsKey(tagName))
            {

                _tagsPool[tagName] = new TagInfo(tagName, true);
                //Console.WriteLine(_tagsPool[tagName]);
            }
            return _tagsPool[tagName];
        }
        
        public static int CachedTagsCount => _tagsPool.Count;
    }
}