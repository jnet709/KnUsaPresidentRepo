﻿using System;
using System.Collections.Generic;
using KnUsaPresident.Models;
using Xamarin.Forms;

namespace KnUsaPresident.Behaviors
{
    public class RadioBehavior : Behavior<View>
    {
        TapGestureRecognizer tapRecognizer;
        static List<RadioBehavior> defaultGroup = new List<RadioBehavior>();
        static Dictionary<string, List<RadioBehavior>> radioGroups =
                                    new Dictionary<string, List<RadioBehavior>>();

        public RadioBehavior()
        {
            defaultGroup.Add(this);
        }

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create("IsChecked",
                                    typeof(bool),
                                    typeof(RadioBehavior),
                                    false,
                                    propertyChanged: OnIsCheckedChanged);

        public bool IsChecked
        {
            set { SetValue(IsCheckedProperty, value); }
            get { return (bool)GetValue(IsCheckedProperty); }
        }

        public static readonly BindableProperty SearchListProperty =
           BindableProperty.Create("IsChecked",
                                   typeof(IList<President>),
                                   typeof(RadioBehavior),
                                   new List<President>());

        #region Search

        public IList<President> SearchList
        {
            set { SetValue(SearchListProperty, value); }
            get { return (IList<President>)GetValue(SearchListProperty); }
        }

        public static readonly BindableProperty SearchByProperty =
            BindableProperty.Create("SearchBy",
                                    typeof(string),
                                    typeof(RadioBehavior),
                                    "Name");

        public string SearchBy
        {
            set { SetValue(SearchByProperty, value); }
            get { return (string)GetValue(SearchByProperty); }
        }

        public static readonly BindableProperty SearchKeyProperty =
            BindableProperty.Create("SearchKey",
                                    typeof(string),
                                    typeof(RadioBehavior),
                                    "");

        public string SearchKey
        {
            set { SetValue(SearchKeyProperty, value); }
            get { return (string)GetValue(SearchKeyProperty); }
        }

        #endregion

        static void OnIsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RadioBehavior behavior = (RadioBehavior)bindable;

            if ((bool)newValue)
            {
                string groupName = behavior.GroupName;
                List<RadioBehavior> behaviors = null;

                if (String.IsNullOrEmpty(groupName))
                {
                    behaviors = defaultGroup;
                }
                else
                {
                    behaviors = radioGroups[groupName];
                }

                foreach (RadioBehavior otherBehavior in behaviors)
                {
                    if (otherBehavior != behavior)
                    {
                        otherBehavior.IsChecked = false;
                    }
                }
            }
        }

        public static readonly BindableProperty GroupNameProperty =
            BindableProperty.Create("GroupName",
                                    typeof(string),
                                    typeof(RadioBehavior),
                                    null,
                                    propertyChanged: OnGroupNameChanged);

        public string GroupName
        {
            set { SetValue(GroupNameProperty, value); }
            get { return (string)GetValue(GroupNameProperty); }
        }

        static void OnGroupNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RadioBehavior behavior = (RadioBehavior)bindable;
            string oldGroupName = (string)oldValue;
            string newGroupName = (string)newValue;

            if (String.IsNullOrEmpty(oldGroupName))
            {
                // Remove the Behavior from the default group.
                defaultGroup.Remove(behavior);
            }
            else
            {
                // Remove the RadioBehavior from the radioGroups collection.
                List<RadioBehavior> behaviors = radioGroups[oldGroupName];
                behaviors.Remove(behavior);

                // Get rid of the collection if there it's empty
                if (behaviors.Count == 0)
                {
                    radioGroups.Remove(oldGroupName);
                }
            }

            if (String.IsNullOrEmpty(newGroupName))
            {
                // Add the new Behavior to the default group.
                defaultGroup.Add(behavior);
            }
            else
            {
                List<RadioBehavior> behaviors = null;

                if (radioGroups.ContainsKey(newGroupName))
                {
                    // Get the named group.
                    behaviors = radioGroups[newGroupName];
                }
                else
                {
                    // If that group doesn't exist, create it.
                    behaviors = new List<RadioBehavior>();
                    radioGroups.Add(newGroupName, behaviors);
                }

                // Add the Behavior to the group.
                behaviors.Add(behavior);
            }
        }

        protected override void OnAttachedTo(View view)
        {
            base.OnAttachedTo(view);

            tapRecognizer = new TapGestureRecognizer();
            tapRecognizer.Tapped += OnTapRecognizerTapped;
            view.GestureRecognizers.Add(tapRecognizer);
        }

        protected override void OnDetachingFrom(View view)
        {
            base.OnDetachingFrom(view);

            view.GestureRecognizers.Remove(tapRecognizer);
            tapRecognizer.Tapped -= OnTapRecognizerTapped;
        }

        void OnTapRecognizerTapped(object sender, EventArgs args)
        {
            IsChecked = true;
            SearchList = PresidentService.Search(SearchKey, SearchBy);
        }
    }
}
