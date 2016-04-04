package RNG;

import java.util.*;

public class MatrixRNG 
{
	private Random RNG = new Random();
	
	public MatrixRNG()
	{
	}
	
	public ArrayList<ArrayList<Integer>> GenerateMatrix(int n, int m)
	{
		ArrayList<ArrayList<Integer>> resultList = new ArrayList<ArrayList<Integer>>();
		for (int i = 0; i < n; i++)
		{
			resultList.add(new ArrayList<Integer>());
			for (int j = 0; j < m; j++)
				resultList.get(i).add(RNG.nextInt());
		}
		
		return resultList;
	}
}
