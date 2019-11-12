using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance.Common.Base
{
	public enum ElementTypeDefs : short
	{
		Wszystko = -1,
		Nieokreslone = 0,
		GPWAkcje = 1,
		GPWObligacje = 2,
		GPWIndeksy = 3
	}

	public enum GraphType
	{
		Linear,
		Candles,
		Bars,
		Volume
	}

	public enum FunctionType
	{
		Min,
		Max,
		Sma,
		Ema,
		Rsi,
		Cci,
		Stochastic,
		Bollinger,
		Moneyflow
	}
}
