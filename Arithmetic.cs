﻿namespace Platform.Numbers
{
    public static class Arithmetic
    {
        public static T Add<T>(T x, T y) => Arithmetic<T>.Add(x, y);
        public static T And<T>(T x, T y) => Arithmetic<T>.And(x, y);
        public static T Increment<T>(T x) => Arithmetic<T>.Increment(x);
        public static T Subtract<T>(T x, T y) => Arithmetic<T>.Subtract(x, y);
        public static T Subtract<T>(Integer<T> x, Integer<T> y) => Arithmetic<T>.Subtract(x, y);
        public static T Decrement<T>(T x) => Arithmetic<T>.Decrement(x);
    }
}