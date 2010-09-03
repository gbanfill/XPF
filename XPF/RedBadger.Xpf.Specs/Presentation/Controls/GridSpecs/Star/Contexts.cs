﻿//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.GridSpecs.Star
{
    using System.Windows;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Presentation.Controls;

    using UIElement = RedBadger.Xpf.Presentation.UIElement;

    public abstract class a_Star_Grid_with_two_rows_and_two_columns : a_Grid
    {
        protected static Mock<UIElement> BottomLeftChild;

        protected static Mock<UIElement> BottomRightChild;

        protected static ColumnDefinition ColumnOneDefinition;

        protected static ColumnDefinition ColumnTwoDefinition;

        protected static RowDefinition RowOneDefinition;

        protected static RowDefinition RowTwoDefinition;

        protected static Mock<UIElement> TopLeftChild;

        protected static Mock<UIElement> TopRightChild;

        private Establish context = () =>
            {
                ColumnOneDefinition = new ColumnDefinition();
                Subject.ColumnDefinitions.Add(ColumnOneDefinition);

                ColumnTwoDefinition = new ColumnDefinition();
                Subject.ColumnDefinitions.Add(ColumnTwoDefinition);

                RowOneDefinition = new RowDefinition();
                Subject.RowDefinitions.Add(RowOneDefinition);

                RowTwoDefinition = new RowDefinition();
                Subject.RowDefinitions.Add(RowTwoDefinition);

                TopLeftChild = new Mock<UIElement> { CallBase = true };
                TopLeftChild.Object.Width = 1;
                TopLeftChild.Object.Height = 2;
                Grid.SetColumn(TopLeftChild.Object, 0);
                Grid.SetRow(TopLeftChild.Object, 0);

                TopRightChild = new Mock<UIElement> { CallBase = true };
                TopRightChild.Object.Width = 3;
                TopRightChild.Object.Height = 4;
                Grid.SetColumn(TopRightChild.Object, 1);
                Grid.SetRow(TopRightChild.Object, 0);

                BottomLeftChild = new Mock<UIElement> { CallBase = true };
                BottomLeftChild.Object.Width = 5;
                BottomLeftChild.Object.Height = 6;
                Grid.SetColumn(BottomLeftChild.Object, 0);
                Grid.SetRow(BottomLeftChild.Object, 1);

                BottomRightChild = new Mock<UIElement> { CallBase = true };
                BottomRightChild.Object.Width = 7;
                BottomRightChild.Object.Height = 8;
                Grid.SetColumn(BottomRightChild.Object, 1);
                Grid.SetRow(BottomRightChild.Object, 1);

                Subject.Children.Add(TopLeftChild.Object);
                Subject.Children.Add(TopRightChild.Object);
                Subject.Children.Add(BottomLeftChild.Object);
                Subject.Children.Add(BottomRightChild.Object);
            };
    }
}