package Matrix;

import java.util.ArrayList;

import RNG.MatrixRNG;

public class Matrix
{
	int lineCount;
	int columnCount;
	private ArrayList<ArrayList<Integer>> content;
	
	public Matrix(int lines, int columns)
	{
		MatrixRNG rng = new MatrixRNG();
		lineCount = lines;
		columnCount = columns;
		content = rng.GenerateMatrix(lines, columns);
	}

	public Matrix(int lines, int columns, int valueToPopulate)
	{
		lineCount = lines;
		columnCount = columns;
		content = new ArrayList<ArrayList<Integer>>();
		for (int i = 0; i < lines; i++)
		{
			content.add(new ArrayList<Integer>());
			for (int j = 0; j < columns; j++)
				content.get(i).add(valueToPopulate);
		}
	}
	
	public Integer GetElement(int line, int column)
	{
		return content.get(line).get(column);
	}
	
	public void AddToElement(int line, int column, int value)
	{
		content.get(line).set(column, value);
	}
	
	public void AdditionWithThreads(Matrix matrixToAdd, int threadCount)
	{
		int elementsPerThread = lineCount * columnCount / threadCount;
		ArrayList<Thread> threadList = new ArrayList<Thread>();
		
		for (int i = 0; i < threadCount - 1; i++)
		{
			Pair startIndex = new Pair(i * elementsPerThread / columnCount, i * elementsPerThread % columnCount);
			Pair endIndex = new Pair(i * elementsPerThread / columnCount, ((i + 1) * elementsPerThread - 1) % columnCount);
			threadList.add(new Thread(new MatrixAdditionThread(startIndex, endIndex, matrixToAdd)));
		}
		
		Pair finalStartIndex = new Pair((threadCount - 1) * elementsPerThread / columnCount, (threadCount - 1) * elementsPerThread % columnCount);
		Pair finalEndIndex = new Pair(lineCount - 1, columnCount - 1);
		threadList.add(new Thread(new MatrixAdditionThread(finalStartIndex, finalEndIndex, matrixToAdd)));
		
		for (int i = 0; i < threadCount; i++)
		{
			System.out.println("Entering thread " + String.valueOf(i));
			threadList.get(i).start();
			try
			{
				System.out.println("Waiting for thread " + String.valueOf(i));
				threadList.get(i).join();
				System.out.println("Thread " + String.valueOf(i) + " ended");
			}
			catch (InterruptedException e)
			{
				System.out.println("Something died!");
			}
		}
		
		for (int i = 0; i < threadCount; i++)
		{

		}
		System.out.println("Done with joins");
	}
	
	private class Pair
	{
		private int line;
		private int column;
		
		public Pair(int i, int j)
		{
			line = i;
			column = j;
		}
		
		public int GetLine()
		{
			return line;
		}
		
		public int GetColumn()
		{
			return column;
		}
	}
	
	private class MatrixAdditionThread implements Runnable
	{
		private Pair startIndex;
		private Pair endIndex;
		private Matrix matrixToAdd;
		
		public MatrixAdditionThread(Pair start, Pair end, Matrix matrix)
		{
			startIndex = start;
			endIndex = end;
			matrixToAdd = matrix;
		}
		
		@Override
		public void run()
		{
			for (int i = startIndex.GetLine(); i <= endIndex.GetLine(); i++)
			{
				int j;
				int maxColumn;
				if (i > startIndex.GetLine())
					j = 0;
				else j = startIndex.GetColumn();
				if (i == endIndex.GetLine())
					maxColumn = endIndex.GetColumn();
				else maxColumn = columnCount - 1;
					
				while (j <= maxColumn)
				{
					AddToElement(i, j, matrixToAdd.GetElement(i, j)); //
					j++;
				}
			}
			System.out.println("Done with thread");
		}
	}
}
