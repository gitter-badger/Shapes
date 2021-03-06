﻿// <copyright file="IShape.cs" company="Scott Williams">
// Copyright (c) Scott Williams and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace SixLabors.Shapes
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Numerics;

    /// <summary>
    /// Represents a closed set of paths making up a single shape.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Gets the bounding box of this shape.
        /// </summary>
        /// <value>
        /// The bounds.
        /// </value>
        Rectangle Bounds { get; }

        /// <summary>
        /// Gets the paths that make up this shape
        /// </summary>
        /// <value>
        /// The paths.
        /// </value>
        ImmutableArray<IPath> Paths { get; }

        /// <summary>
        /// Gets the maximum number intersections that a shape can have when testing a line.
        /// </summary>
        /// <value>
        /// The maximum intersections.
        /// </value>
        int MaxIntersections { get; }

        /// <summary>
        /// the distance of the point from the outline of the shape, if the value is negative it is inside the polygon bounds
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        /// Returns the distance from the shape to the point
        /// </returns>
        float Distance(Vector2 point);

        /// <summary>
        /// Determines whether the <see cref="IShape"/> contains the specified point
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the <see cref="IShape"/> contains the specified point; otherwise, <c>false</c>.
        /// </returns>
        bool Contains(Vector2 point);

        /// <summary>
        /// Based on a line described by <paramref name="start"/> and <paramref name="end"/>
        /// populate a buffer for all points on the polygon that the line intersects.
        /// </summary>
        /// <param name="start">The start point of the line.</param>
        /// <param name="end">The end point of the line.</param>
        /// <param name="buffer">The buffer that will be populated with intersections.</param>
        /// <param name="count">The count.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>
        /// The number of intersections populated into the buffer.
        /// </returns>
        int FindIntersections(Vector2 start, Vector2 end, Vector2[] buffer, int count, int offset);

        /// <summary>
        /// Based on a line described by <paramref name="start"/> and <paramref name="end"/>
        /// populate a buffer for all points on the polygon that the line intersects.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>The locations along the line segment that intersect with the edges of the shape.</returns>
        IEnumerable<Vector2> FindIntersections(Vector2 start, Vector2 end);

        /// <summary>
        /// Transforms the shape using the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>A new shape with the matrix applied to it.</returns>
        IShape Transform(Matrix3x2 matrix);
    }
}
