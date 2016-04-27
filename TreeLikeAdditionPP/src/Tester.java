import java.util.ArrayList;
import java.util.TreeMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

/**
 * Created by ciprian.vilcan on 25-Apr-16.
 */
public class Tester {
    public void Test()
    {
//        for (int k = 8; k <= 8; k++)
//        {
//            System.out.println("Testing " + k + "...");
//            ArrayList<Integer> arrayList = new ArrayList<>();
//            for (int i = 0; i < k; i++)
//                arrayList.add(i);
//
//            TreeMap<Integer, Element> sumList = new TreeMap<Integer, Element>();
//            ExecutorService es = Executors.newFixedThreadPool(arrayList.size() / 2 + arrayList.size() % 2);
//            for (int i = 0; i < arrayList.size() / 2 + arrayList.size() % 2; i++)
//                sumList.put(i, new Element());
//            for (int i = 0; i < arrayList.size() / 2 + arrayList.size() % 2; i++)
//            {
//                es.execute(new AdditionThread(arrayList, i * 2, sumList));
//                try
//                {
//                    es.awaitTermination(Long.MAX_VALUE, TimeUnit.NANOSECONDS);
//                }
//                catch (Exception e)
//                {
//
//                }
//            }
//        }


        for (int k = 1; k < 1000; k++)
        {
            System.out.println("Testing " + k + "...");
            ArrayList<Integer> arrayList = new ArrayList<>();
            for (int i = 0; i < k; i++)
                arrayList.add(i);

            TreeMap<Integer, Element> sumList = new TreeMap<Integer, Element>();
            for (int i = 0; i < arrayList.size() / 2 + arrayList.size() % 2; i++)
                sumList.put(i, new Element());

//            ArrayList<Thread> threadList = new ArrayList<>();
//            for (int i = 0; i < arrayList.size() / 2 + arrayList.size() % 2; i++)
//            {
//                threadList.add(new Thread(new AdditionThread(arrayList, i * 2, sumList)));
//                threadList.get(i).start();
//            }
//
//            boolean done = false;
//            while (!done)
//            {
//                int i = 0;
//                done = true;
//                while (i < threadList.size())
//                {
//                    if (threadList.get(i).isAlive())
//                        done = false;
//                    i++;
//                }
//            }
            ExecutorService es = Executors.newFixedThreadPool(arrayList.size() / 2 + arrayList.size() % 2);
            for (int i = 0; i < arrayList.size() / 2 + arrayList.size() % 2; i++)
                es.execute(new AdditionThread(arrayList, i * 2, sumList));

            es.shutdown();
            try {
                es.awaitTermination(Long.MAX_VALUE, TimeUnit.NANOSECONDS);
            } catch (InterruptedException e) {
            }
            if (sumList.get(0).value != (k - 1) * k / 2)
                System.out.println("Failed for " + k);
        }
    }
}
