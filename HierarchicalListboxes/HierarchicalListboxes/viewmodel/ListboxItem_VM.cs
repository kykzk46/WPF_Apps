using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFoundation.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HierarchicalListboxes.viewmodel
{
    class ListboxItem_VM : ObservableObject
    {
        /// <summary>
        /// </summary>
        /// <param name="items"></param>
        /// <param name="hierarchyLevel">Determine the useful character of ListBoxSelectedItem</param>
        /// <param name="childListbox"></param>
        public ListboxItem_VM(List<string> items, int hierarchyLevel)
        {
            _allItems = items;
            _ListBoxVisibleItems = new ObservableCollection<string>(_allItems);
            _hierarchyLevel = hierarchyLevel;
        }

        int _hierarchyLevel;
        List<string> _allItems;
        public ListboxItem_VM ChildListbox;

        ObservableCollection<string> _ListBoxVisibleItems;
        public ObservableCollection<string> ListBoxVisibleItems
        {
            get { return _ListBoxVisibleItems; }
            set
            {
                if (value != _ListBoxVisibleItems)
                {
                    _ListBoxVisibleItems = value;
                    RaisePropertyChanged("ListBoxVisibleItems");

                    if (ChildListbox != null)
                    {
                        ChildListbox.SetFilter4ItemSources(
                            _hierarchyLevel,
                            (from i in _ListBoxVisibleItems
                             select i.Substring(0, _hierarchyLevel))
                            .Distinct<string>()
                            .ToList()
                            );
                    }
                }
            }
        }

        string _ListBoxSelectedItem = "";
        public string ListBoxSelectedItem
        {
            get { return _ListBoxSelectedItem; }
            set
            {
                if (value != _ListBoxSelectedItem)
                {
                    _ListBoxSelectedItem = value;
                    RaisePropertyChanged("ListBoxSelectedItem");

                    if (ChildListbox != null)
                    {
                        if (_ListBoxSelectedItem != null)
                        {

                            ChildListbox.SetFilter4ItemSources(
                                _hierarchyLevel,
                                new List<string> { _ListBoxSelectedItem.Substring(0, _hierarchyLevel) }
                                );
                        }
                        else
                        {
                            ChildListbox.SetFilter4ItemSources(0, null);
                        }
                    }
                }
            }
        }

        public void SetFilter4ItemSources(int filterLength, List<string> filter)
        {
            if (filterLength > 0)
            {
                ListBoxVisibleItems = new ObservableCollection<string>(
                    from i in _allItems
                    where filter.Contains(i.Substring(0, filterLength))
                    select i
                 );
            }
            else
            {
                ListBoxVisibleItems = new ObservableCollection<string>(_allItems);
            }
        }
    }
}
