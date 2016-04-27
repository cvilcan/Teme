import java.lang.reflect.Array;
import java.util.*;
import java.util.concurrent.Callable;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

/**
 * Created by ciprian.vilcan on 25-Apr-16.
 */
public class AdditionThread implements Runnable {
    private List<Integer> _array;
    private int _position;
    private int _sum;
    private TreeMap<Integer, Element> _sumList;

    public AdditionThread(List<Integer> array, int thisPosition, TreeMap<Integer, Element> sumList)
    {
        _array = array;
        _position = thisPosition;
        _sum = 0;
        _sumList = sumList;
    }

//    @Override
//    public void run() {
//        System.out.println("Executing thread " + Thread.currentThread().getName());
//        synchronized (_sumList) {
//            if (_position + 1 < _array.size())
//                _sumList.put(_position / 2, new Element(_array.get(_position) + _array.get(_position + 1), 0));
//            else _sumList.put(_position / 2, new Element(_array.get(_position), 0));
//        }
//
//        _position = _position / 2;
//        if (_position % 2 == 0)
//            while (_sumList.ceilingEntry(_position + 1) != null)
//            {
//                while (!readyToAdd(_position))
//                { }
//
//                //while (_sumList.get(_position) == _sumList.get(_position + 1)) { }
//                synchronized (_sumList) {
//                    _sumList.put(_position, new Element(_sumList.get(_position).value + _sumList.ceilingEntry(_position + 1).getValue().value, _sumList.get(_position).level + 1));
//                    _sumList.remove(_sumList.ceilingEntry(_position + 1).getKey());
//                }
//            }
//        System.out.println("Executed thread " + Thread.currentThread().getName());
//    }

//    private boolean readyToAdd(int position) {
//        boolean readyToAdd = true;
//        ArrayList<Integer> valueList = new ArrayList<>(_sumList.keySet());
//        ListIterator<Integer> iterator = valueList.listIterator();
//        for (Integer i = 0; i < valueList.size() - 1; i++)
//        {
//            if ((_sumList.get(valueList.get(i)).level == _sumList.get(valueList.get(i + 1)).level) || (_sumList.get(valueList.get(i)).level == -1) || (_sumList.get(valueList.get(i + 1)).level == -1))
//                readyToAdd = false;
//        }
//
//        return readyToAdd || (_sumList.get(valueList.get(_position)).level == _sumList.get(valueList.get(_position + 1)).level);
////        (_sumList.ceilingEntry(_position + 1).getValue().level != _sumList.get(_position).level)
////                && (_sumList.size() % 2 == 0) && (_sumList.ceilingEntry(_position + 2) != null))
//    }

    private boolean readyToAdd(int threadNumber)
    {
        synchronized (_sumList) {
            boolean noTwoEqualLevels = true;
            ArrayList<Integer> keyList = new ArrayList<>(_sumList.keySet());
            for (int i = 0; i < keyList.size() - 1; i++) {
                int firstKey = keyList.get(i);
                int secondKey = keyList.get(i + 1);
                Element firstElement = _sumList.get(firstKey);
                Element secondElement = _sumList.get(secondKey);
                if (_sumList.get(firstKey).level
                        == _sumList.ceilingEntry(secondKey).getValue().level)
                    noTwoEqualLevels = false;
                if (_sumList.get(firstKey).level == -1)
                    noTwoEqualLevels = false;
                if (_sumList.ceilingEntry(secondKey).getValue().level == -1)
                    noTwoEqualLevels = false;
            }

            boolean thisLevelEqualToNextLevel = false;
            if (_sumList.ceilingEntry(threadNumber + 1) == null)
                thisLevelEqualToNextLevel = false;
            else if (_sumList.get(threadNumber) == null)
                thisLevelEqualToNextLevel = false;
            else if (_sumList.get(threadNumber).level
                    == _sumList.ceilingEntry(threadNumber + 1).getValue().level)
                thisLevelEqualToNextLevel = true;

            return noTwoEqualLevels || thisLevelEqualToNextLevel;
        }
    }

    @Override
    public void run() {
        int threadNumber = _position / 2;
        if (_position + 1 >= _array.size())
            _sumList.put(threadNumber, new Element(_array.get(_position), 0));
        else _sumList.put(threadNumber, new Element(_array.get(_position) + _array.get(_position + 1), 0));

        while ((_sumList.lastEntry().getKey() > threadNumber) && (_sumList.get(threadNumber) != null))
        {
            Object lock = false;
            synchronized (lock) {
                if (currentElementNotNull(threadNumber) && (rightNeighbourReadyAndOnSameLevel(threadNumber) || allRightNeighboursToRightHaveUnequalLevels(threadNumber))
                        && noNegativeLevelNeighbourToTheRight(threadNumber)) {
                    Map.Entry neighbourToTheRight = _sumList.ceilingEntry(threadNumber + 1);
                    _sumList.put(threadNumber, new Element(_sumList.get(threadNumber).value + ((Element) neighbourToTheRight.getValue()).value,
                            _sumList.get(threadNumber).level + 1));
                    _sumList.remove(neighbourToTheRight.getKey());
                }
            }
        }
    }

    private boolean currentElementNotNull(int threadNumber) {
        return (_sumList.get(threadNumber) != null);
    }

    private boolean noNegativeLevelNeighbourToTheRight(int threadNumber) {
        boolean noNegativeLevelToTheRight = true;

        int threadIterator = threadNumber + 1;
        while (_sumList.containsKey(threadIterator))
        {
            if (_sumList.get(threadIterator).level == -1)
                noNegativeLevelToTheRight = false;

            threadIterator++;
        }

        return noNegativeLevelToTheRight;
    }

    private boolean allRightNeighboursToRightHaveUnequalLevels(int threadNumber) {
        boolean noEqualLevelsToTheRight = true;

        int threadIterator = threadNumber + 1;
        while (_sumList.containsKey(threadIterator))
        {
            if (_sumList.containsKey(threadIterator + 1))
            {
                if (_sumList.get(threadIterator).level == _sumList.get(threadIterator + 1).level)
                    noEqualLevelsToTheRight = false;
            }

            threadIterator++;
        }

        return noEqualLevelsToTheRight;
    }

    private boolean rightNeighbourReadyAndOnSameLevel(int threadNumber) {
        boolean existsReadyAndOnSameLevel = false;

        if (_sumList.ceilingEntry(threadNumber + 1) == null)
            existsReadyAndOnSameLevel = false;
        else
        {
            Element rightNeighbour = _sumList.ceilingEntry(threadNumber + 1).getValue();
            if (_sumList.get(threadNumber).level == rightNeighbour.level)
                existsReadyAndOnSameLevel = true;
        }

        return existsReadyAndOnSameLevel;
    }
}
