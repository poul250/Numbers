﻿using BenchmarkDotNet.Attributes;
using Platform.Converters;

#pragma warning disable CA1822 // Mark members as static

namespace Platform.Numbers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class IntegerBenchmarks
    {
        [Params(10000, 1000000, 100000000)]
        public int N { get; set; }

        private static Converter<ulong> _converter;

        public class Converter<TLink> : IConverter<TLink>
        {
            public TLink Convert(TLink source) => (Integer<TLink>)2L;
        }

        [GlobalSetup]
        public static void Setup() => _converter = new Converter<ulong>();

        [Benchmark]
        public ulong ToUInt64UsingUncheckedConverter() => UncheckedConverter<uint, ulong>.Default.Convert(2U);

        [Benchmark]
        public long ToInt64UsingUncheckedConverter() => UncheckedConverter<uint, long>.Default.Convert(2U);

        [Benchmark]
        public ulong ToUInt64UsingInteger() => (Integer)2U;

        [Benchmark]
        public long ToInt64UsingInteger() => (Integer)2U;

        [Benchmark]
        public ulong ToUInt64UsingTypedInteger() => (Integer<int>)2U;

        [Benchmark]
        public long ToInt64UsingTypedInteger() => (Integer<int>)2U;

        [Benchmark]
        public ulong ToInt64UsingTypedIntegerInsideClassWrapper() => _converter.Convert(0);
    }
}
