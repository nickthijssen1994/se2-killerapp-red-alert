using System;

namespace KillerAppASP.Helperclasses
{
	public static class PerlinNoiseGenerator
	{
		/*
		 * Original from https://github.com/WardBenjamin/SimplexNoise.git
		*/
		private static readonly int seed = 1;
		private static byte[] noise;

		public static int Seed
		{
			get => seed;
			set
			{
				noise = new byte[512];
				var random = new Random(value);
				random.NextBytes(noise);
			}
		}

		public static float[,] GenerateMap(int size, int seed)
		{
			Seed = seed;

			float MinValue = 0;
			float MaxValue = 0;
			var heightValues = new float[size, size];

			for (var y = 0; y < size; y++)
			{
				for (var x = 0; x < size; x++)
				{
					var heightValue = ApplyOctaves(x, y, 8);
					if (heightValue < -1.0f) heightValue = -1.0f;
					if (heightValue > 1.0f) heightValue = 1.0f;
					if (heightValue > MaxValue) MaxValue = heightValue;
					if (heightValue < MinValue) MinValue = heightValue;
					heightValues[x, y] = heightValue;
				}
			}

			for (var y = 0; y < size; y++)
			{
				for (var x = 0; x < size; x++)
				{
					var heigthValue = heightValues[x, y];
					var scale = 1 / (MaxValue - MinValue);
					heigthValue = (heigthValue - MinValue) * scale;
					heightValues[x, y] = heigthValue;
				}
			}

			return heightValues;
		}

		private static float ApplyOctaves(float x, float y, int octave)
		{
			float total = 0;
			var frequency = 0.005f;
			float amplitude = 1;
			for (var i = 0; i < octave; i++)
			{
				amplitude /= 2;
				frequency *= 2;
				total += Generate(x * frequency, y * frequency) * amplitude;
			}

			return total;
		}

		private static float Generate(float x, float y)
		{
			const float F2 = 0.366025403f; // F2 = 0.5*(sqrt(3.0)-1.0)
			const float G2 = 0.211324865f; // G2 = (3.0-Math.sqrt(3.0))/6.0

			float n0, n1, n2; // Noise contributions from the three corners

			// Skew the input space to determine which simplex cell we're in
			var s = (x + y) * F2; // Hairy factor for 2D
			var xs = x + s;
			var ys = y + s;
			var i = FastFloor(xs);
			var j = FastFloor(ys);

			var t = (i + j) * G2;
			var X0 = i - t; // Unskew the cell origin back to (x,y) space
			var Y0 = j - t;
			var x0 = x - X0; // The x,y distances from the cell origin
			var y0 = y - Y0;

			// For the 2D case, the simplex shape is an equilateral triangle.
			// Determine which simplex we are in.
			int i1, j1; // Offsets for second (middle) corner of simplex in (i,j) coords
			if (x0 > y0)
			{
				i1 = 1;
				j1 = 0;
			} // lower triangle, XY order: (0,0)->(1,0)->(1,1)
			else
			{
				i1 = 0;
				j1 = 1;
			} // upper triangle, YX order: (0,0)->(0,1)->(1,1)

			// A step of (1,0) in (i,j) means a step of (1-c,-c) in (x,y), and
			// a step of (0,1) in (i,j) means a step of (-c,1-c) in (x,y), where
			// c = (3-sqrt(3))/6

			var x1 = x0 - i1 + G2; // Offsets for middle corner in (x,y) unskewed coords
			var y1 = y0 - j1 + G2;
			var x2 = x0 - 1.0f + 2.0f * G2; // Offsets for last corner in (x,y) unskewed coords
			var y2 = y0 - 1.0f + 2.0f * G2;

			// Wrap the integer indices at 256, to avoid indexing perm[] out of bounds
			var ii = i % 256;
			var jj = j % 256;

			// Calculate the contribution from the three corners
			var t0 = 0.5f - x0 * x0 - y0 * y0;
			if (t0 < 0.0f)
			{
				n0 = 0.0f;
			}
			else
			{
				t0 *= t0;
				n0 = t0 * t0 * Grad(noise[ii + noise[jj]], x0, y0);
			}

			var t1 = 0.5f - x1 * x1 - y1 * y1;
			if (t1 < 0.0f)
			{
				n1 = 0.0f;
			}
			else
			{
				t1 *= t1;
				n1 = t1 * t1 * Grad(noise[ii + i1 + noise[jj + j1]], x1, y1);
			}

			var t2 = 0.5f - x2 * x2 - y2 * y2;
			if (t2 < 0.0f)
			{
				n2 = 0.0f;
			}
			else
			{
				t2 *= t2;
				n2 = t2 * t2 * Grad(noise[ii + 1 + noise[jj + 1]], x2, y2);
			}

			// Add contributions from each corner to get the final noise value.
			// The result is scaled to return values in the interval [-1,1].
			return 40.0f * (n0 + n1 + n2); // TODO: The scale factor is preliminary!
		}

		private static int FastFloor(float x)
		{
			return x > 0 ? (int) x : (int) x - 1;
		}

		private static float Grad(int hash, float x, float y)
		{
			var h = hash & 7; // Convert low 3 bits of hash code
			var u = h < 4 ? x : y; // into 8 simple gradient directions,
			var v = h < 4 ? y : x; // and compute the dot product with (x,y).
			return ((h & 1) != 0 ? -u : u) + ((h & 2) != 0 ? -2.0f * v : 2.0f * v);
		}
	}
}