﻿using Flepper.QueryBuilder;
using FluentAssertions;
using Xunit;

namespace Flepper.Tests.Unit.QueryBuilder.Commands
{
    [Collection("CommandTests")]
    public class WhereFilterTests
    {
        [Fact]
        public void ShouldContainsWhereInStatement()
        {
            FlepperQueryBuilder.Select()
                .From("user").Where("name");
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE");
        }

        [Fact]
        public void ShouldContainsWhereWithComparisonOperatos()
        {
            FlepperQueryBuilder.Select()
                .From("user")
                .Where("name")
                .EqualTo("gustavo");
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [name] = 'gustavo'");
        }

        [Fact]
        public void ShouldContainsWhereWithLogicalOperator()
        {
            FlepperQueryBuilder.Select()
                .From("user")
                .Where("name")
                .EqualTo("gustavo")
                .And("age");
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [name] = 'gustavo' AND [age]");
        }

        [Fact]
        public void ShouldContainsWhereWithLogicalOperatorWithComparisonOperators()
        {
            FlepperQueryBuilder.Select()
                .From("user")
                .Where("name")
                .EqualTo("gustavo")
                .And("age")
                .EqualTo(26);
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [name] = 'gustavo' AND [age] = 26");
        }

        [Fact]
        public void ShoulContainWhereWithNotEqual()
        {
            FlepperQueryBuilder.Select()
                .From("table")
                .Where("field").NotEqualTo("value");
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [field] <> 'value'");
        }

        [Fact]
        public void ShoulContainWhereWithGreaterThan()
        {
            FlepperQueryBuilder.Select()
                .From("table")
                .Where("field").GreaterThan(1);
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [field] > 1");
        }

        [Fact]
        public void ShoulContainWhereWithLessThan()
        {
            FlepperQueryBuilder.Select()
                .From("table")
                .Where("field").LessThan(1);
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [field] < 1");
        }

        [Fact]
        public void ShoulContainWhereWithGreaterThanOrEqualTo()
        {
            FlepperQueryBuilder.Select()
                .From("table")
                .Where("field").GreaterThanOrEqualTo(1);
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [field] >= 1");
        }

        [Fact]
        {
            FlepperQueryBuilder.Select()
                .From("table")
                .Where("field").LessThanOrEqualTo(1);
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [field] <= 1");
        }

        [Fact]
        public void ShoulContainWhereWithNotEqualTo()
        {
            FlepperQueryBuilder.Select()
                .From("table")
                .Where("field").NotEqualTo(1);
            FlepperQueryBuilder.Build();
            FlepperQueryBuilder.Query
                .Trim()
                .Should()
                .Contain("WHERE [field] <> 1");
        }
    }
}
