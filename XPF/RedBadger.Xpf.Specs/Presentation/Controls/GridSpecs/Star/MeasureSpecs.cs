//-------------------------------------------------------------------------------------------------
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
    using Moq.Protected;

    using RedBadger.Xpf.Presentation.Controls;

    using It = Machine.Specifications.It;
    using UIElement = RedBadger.Xpf.Presentation.UIElement;

    using RedBadger.Xpf.Internal;

    using System.Linq;

    [Subject(typeof(Grid), "Measure - Star")]
    public class when_an_element_is_added : a_Grid
    {
        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 50;
                child.Object.Height = 60;

                Subject.Children.Add(child.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => child.Protected().Verify(
                MeasureOverride, Times.Once(), ItExpr.Is<Size>(value => value.Equals(AvailableSize)));
    }

    [Subject(typeof(Grid), "Measure - Star")]
    public class when_there_are_two_rows_and_two_columns : a_Star_Grid_with_two_rows_and_two_columns
    {
        private static readonly Size expectedCellSize = new Size(AvailableSize.Width / 2, AvailableSize.Height / 2);

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_allocate_a_quarter_of_the_space_to_cell_1 =
            () =>
            TopLeftChild.Protected().Verify(
                MeasureOverride, Times.Once(), ItExpr.Is<Size>(value => value.Equals(expectedCellSize)));

        private It should_allocate_a_quarter_of_the_space_to_cell_2 =
            () =>
            TopRightChild.Protected().Verify(
                MeasureOverride, Times.Once(), ItExpr.Is<Size>(value => value.Equals(expectedCellSize)));

        private It should_allocate_a_quarter_of_the_space_to_cell_3 =
            () =>
            BottomLeftChild.Protected().Verify(
                MeasureOverride, Times.Once(), ItExpr.Is<Size>(value => value.Equals(expectedCellSize)));

        private It should_allocate_a_quarter_of_the_space_to_cell_4 =
            () =>
            BottomRightChild.Protected().Verify(
                MeasureOverride, Times.Once(), ItExpr.Is<Size>(value => value.Equals(expectedCellSize)));

        private It should_have_a_desired_size_equal_to_the_sum_of_the_largest_children_in_each_row_and_column =
            () =>
            Subject.DesiredSize.ShouldEqual(
                new Size(
                BottomLeftChild.Object.Width + BottomRightChild.Object.Width,
                TopRightChild.Object.Height + BottomRightChild.Object.Height));
    }

    [Subject(typeof(Grid), "Measure - Star")]
    public class when_a_3_x_3_grid_has_differing_cell_sizes : a_Grid
    {
        private static readonly Mock<UIElement>[,] children = new Mock<UIElement>[3,3];

        private static readonly double heightUnit = AvailableSize.Height / 6;

        private static readonly double widthUnit = AvailableSize.Width / 6;

        private Establish context = () =>
            {
                for (int row = 0; row < 3; row++)
                {
                    Subject.RowDefinitions.Add(
                        new RowDefinition { Height = new GridLength(row + 1, GridUnitType.Star) });
                }

                for (int col = 0; col < 3; col++)
                {
                    Subject.ColumnDefinitions.Add(
                        new ColumnDefinition { Width = new GridLength(col + 1, GridUnitType.Star) });
                }

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        var child = new Mock<UIElement> { CallBase = true };
                        Subject.Children.Add(child.Object);
                        Grid.SetColumn(child.Object, col);
                        Grid.SetRow(child.Object, row);

                        children[row, col] = child;
                    }
                }
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_give_each_cell_the_correct_space = () =>
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        var expectedSize = new Size(widthUnit * (col + 1), heightUnit * (row + 1));
                        children[row, col].Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => !size.IsDifferentFrom(expectedSize)));
                    }
                }
            };
    }

    [Subject(typeof(Grid), "Measure - Star")]
    public class when_a_child_element_is_bigger_than_the_available_size : a_Grid
    {
        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 240;
                child.Object.Height = 250;
                Subject.Children.Add(child.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_not_affect_the_desired_size = () => Subject.DesiredSize.ShouldEqual(AvailableSize);
    }

    [Subject(typeof(Grid), "Measure Star - Min and Max")]
    public class when_there_is_a_column_with_min_width_that_exceeds_its_proportional_allocation : a_Grid
    {
        private const double ColumnMinWidth = 100;

        private static readonly double expectedProportionalWidth = AvailableSize.Width / 3;

        private static Mock<UIElement> child1;

        private static Mock<UIElement> child2;

        private static Mock<UIElement> child3;

        private Establish context = () =>
            {
                Subject.ColumnDefinitions.Add(new ColumnDefinition { MinWidth = ColumnMinWidth });
                Subject.ColumnDefinitions.Add(new ColumnDefinition());
                Subject.ColumnDefinitions.Add(new ColumnDefinition());

                child1 = new Mock<UIElement> { CallBase = true };
                child2 = new Mock<UIElement> { CallBase = true };
                child3 = new Mock<UIElement> { CallBase = true };

                Grid.SetColumn(child1.Object, 0);
                Grid.SetColumn(child2.Object, 1);
                Grid.SetColumn(child3.Object, 2);

                Subject.Children.Add(child1.Object);
                Subject.Children.Add(child2.Object);
                Subject.Children.Add(child3.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_1_allocate_more_width_to_that_column =
            () => child1.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Width.Equals(ColumnMinWidth)));

        private It should_2_allocate_the_available_height_to_that_column =
            () => child1.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Height.Equals(AvailableSize.Height)));

        private It should_3_allocate_a_proportional_width_that_ignores_the_min_width_to_subsequent_column_1 =
            () => child2.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Width.IsCloseTo(expectedProportionalWidth)));

        private It should_4_allocate_a_proportional_width_that_ignores_the_min_width_to_subsequent_column_2 =
            () => child3.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Width.IsCloseTo(expectedProportionalWidth)));
    }

    [Subject(typeof(Grid), "Measure Star - Min and Max")]
    public class when_there_is_a_column_with_max_width_that_is_less_than_its_proportional_allocation : a_Grid
    {
        private const double ColumnMaxWidth = 50;

        private static readonly double expectedSubsequentWidth = (AvailableSize.Width - ColumnMaxWidth) / 2;

        private static Mock<UIElement> child1;

        private static Mock<UIElement> child2;

        private static Mock<UIElement> child3;

        private Establish context = () =>
            {
                Subject.ColumnDefinitions.Add(new ColumnDefinition { MaxWidth = ColumnMaxWidth });
                Subject.ColumnDefinitions.Add(new ColumnDefinition());
                Subject.ColumnDefinitions.Add(new ColumnDefinition());

                child1 = new Mock<UIElement> { CallBase = true };
                child2 = new Mock<UIElement> { CallBase = true };
                child3 = new Mock<UIElement> { CallBase = true };

                Grid.SetColumn(child1.Object, 0);
                Grid.SetColumn(child2.Object, 1);
                Grid.SetColumn(child3.Object, 2);

                Subject.Children.Add(child1.Object);
                Subject.Children.Add(child2.Object);
                Subject.Children.Add(child3.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_1_allocate_less_width_to_that_column =
            () => child1.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Width.Equals(ColumnMaxWidth)));

        private It should_2_allocate_the_available_height_to_that_column =
            () => child1.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Height.Equals(AvailableSize.Height)));

        private It should_3_allocate_more_width_to_subsequent_column_1 =
            () => child2.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Width.IsCloseTo(expectedSubsequentWidth)));

        private It should_4_allocate_more_width_to_subsequent_column_2 =
            () => child3.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Width.IsCloseTo(expectedSubsequentWidth)));
    }

    [Subject(typeof(Grid), "Measure Star - Min and Max")]
    public class when_there_is_a_row_with_min_height_that_exceeds_its_proportional_allocation : a_Grid
    {
        private const double RowMinHeight = 100;

        private static readonly double expectedProportionalHeight = AvailableSize.Height / 3;

        private static Mock<UIElement> child1;

        private static Mock<UIElement> child2;

        private static Mock<UIElement> child3;

        private Establish context = () =>
        {
            Subject.RowDefinitions.Add(new RowDefinition { MinHeight = RowMinHeight });
            Subject.RowDefinitions.Add(new RowDefinition());
            Subject.RowDefinitions.Add(new RowDefinition());

            child1 = new Mock<UIElement> { CallBase = true };
            child2 = new Mock<UIElement> { CallBase = true };
            child3 = new Mock<UIElement> { CallBase = true };

            Grid.SetRow(child1.Object, 0);
            Grid.SetRow(child2.Object, 1);
            Grid.SetRow(child3.Object, 2);

            Subject.Children.Add(child1.Object);
            Subject.Children.Add(child2.Object);
            Subject.Children.Add(child3.Object);
        };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_1_allocate_more_height_to_that_row =
            () => child1.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Height.Equals(RowMinHeight)));

        private It should_2_allocate_the_available_width_to_that_row =
            () => child1.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Width.Equals(AvailableSize.Width)));

        private It should_3_allocate_a_proportional_height_that_ignores_the_min_height_to_subsequent_row_1 =
            () => child2.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Height.IsCloseTo(expectedProportionalHeight)));

        private It should_4_allocate_a_proportional_height_that_ignores_the_min_height_to_subsequent_row_2 =
            () => child3.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Height.IsCloseTo(expectedProportionalHeight)));
    }

    [Subject(typeof(Grid), "Measure Star - Min and Max")]
    public class when_there_is_a_row_with_max_height_that_is_less_than_its_proportional_allocation : a_Grid
    {
        private const double RowMaxHeight = 50;

        private static readonly double expectedSubsequentHeight = (AvailableSize.Height - RowMaxHeight) / 2;

        private static Mock<UIElement> child1;

        private static Mock<UIElement> child2;

        private static Mock<UIElement> child3;

        private Establish context = () =>
        {
            Subject.RowDefinitions.Add(new RowDefinition { MaxHeight = RowMaxHeight });
            Subject.RowDefinitions.Add(new RowDefinition());
            Subject.RowDefinitions.Add(new RowDefinition());

            child1 = new Mock<UIElement> { CallBase = true };
            child2 = new Mock<UIElement> { CallBase = true };
            child3 = new Mock<UIElement> { CallBase = true };

            Grid.SetRow(child1.Object, 0);
            Grid.SetRow(child2.Object, 1);
            Grid.SetRow(child3.Object, 2);

            Subject.Children.Add(child1.Object);
            Subject.Children.Add(child2.Object);
            Subject.Children.Add(child3.Object);
        };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_1_allocate_less_height_to_that_row =
            () => child1.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Height.Equals(RowMaxHeight)));

        private It should_2_allocate_the_available_width_to_that_row =
            () => child1.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Width.Equals(AvailableSize.Width)));

        private It should_3_allocate_more_height_to_subsequent_row_1 =
            () => child2.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Height.IsCloseTo(expectedSubsequentHeight)));

        private It should_4_allocate_more_height_to_subsequent_row_2 =
            () => child3.Protected().Verify(
                            MeasureOverride, Times.Once(), ItExpr.Is<Size>(size => size.Height.IsCloseTo(expectedSubsequentHeight)));
    }
}