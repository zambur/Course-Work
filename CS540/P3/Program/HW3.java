import java.io.BufferedReader;
import java.io.FileReader;

/**
 * Do not modify.
 * 
 */
public class HW3 {

  /**
   * Runs the tests for HW3
   */
  public static void main(String[] args) {
    if (args.length < 3) {
      System.out
        .println("usage: java HW3 <modeFlag: 0, 1, 2, 3> <trainFilename> " 
                  + "<testFilename>");
      System.out.println("OR");
      System.out
          .println("usage: java HW3 <modeFlag: 4, 5, 6> <trainFilename> " 
                  + "<testFilename> <tuneFilename>");
      System.exit(-1);
    }

    /*
     * mode 0 : output the mutual information of each attribute at the root node 
     * mode 1 : create a decision tree from a training set, output the tree 
     * mode 2 : create a decision tree from a training set, output the classifications of a test set
     * mode 3 : create a decision tree from a training set, output the accuracy
     * mode 4 : create a decision tree from a training set, then tune, output the tree 
     * mode 5 : create a decision tree from a training set then tune, output
     * the classifications of a test set
     * mode 6 : create a decision tree from a training set then tune, output
     * the accuracy
     */
    int mode = Integer.parseInt(args[0]);
    if (0 > mode || mode > 6) {
      System.out.println("mode must be between 0 and 6");
      System.exit(-1);
    }

    if (mode == 0) {
      (new DecisionTreeImpl()).rootInfoGain(createDataSet(args[1]));
      return;
    }

    // Turn text into array
    // Only create the sets that we intend to use
    // Verify that our attributes and labels are consistent in ordering across sets
    DataSet trainSet = createDataSet(args[1]);
    DataSet tuneSet = null;
    if (mode >= 4) {
      tuneSet = createDataSet(args[3]);
      if (!trainSet.sameMetaValues(tuneSet)) {
        System.out.println("bad meta-values in tune set");
        System.exit(-1);
      }
    }
    DataSet testSet = null;
    if (mode == 2 || mode == 3 || mode == 5 || mode == 6) {
      testSet = createDataSet(args[2]);
      if (!trainSet.sameMetaValues(testSet)) {
        System.out.println("bad meta-values in test set");
        System.exit(-1);
      }
    }

    // Create decision tree
    DecisionTree tree = null;
    if (mode <= 3) {
      tree = new DecisionTreeImpl(trainSet);
      // Print accuracy of test
      if (mode == 3) {
        tree.printAccuracy(testSet);
      }
    } else {
      tree = new DecisionTreeImpl(trainSet, tuneSet);
      // print accuracy of test
      if(mode == 6) {
        tree.printAccuracy(testSet);
      }
    }

    // Run test
    if (mode == 1 || mode == 4) {
      tree.print();
    } else if(mode == 2 || mode == 5){
      for (Instance instance : testSet.instances) {
        System.out.println(tree.classify(instance));
      }
    }
  
  }

  /**
   * Converts from text file format to DataSet format. From the homework spec: All data files
   * (training, tuning, test) will contain a list of classes and attribute values, followed by the
   * actual data. Attributes and classes are always discretely valued. A line that begins with a
   * double slash // is a comment and should be ignored. In other lines, elements will be
   * comma-separated. For a line beginning with %%, it contains two possible classes. Each line that
   * begins with ## specifies the name and all possible discrete values of one attribute. The order
   * of successive attributes is important as this is the same order used in each of the examples in
   * the file.
   */
  private static DataSet createDataSet(String file) {
    DataSet set = new DataSet();
    BufferedReader in;
    try {
      in = new BufferedReader(new FileReader(file));
      while (in.ready()) {
        String line = in.readLine();
        String prefix = line.substring(0, 2);
        if (prefix.equals("//")) {
        } else if (prefix.equals("%%")) {
          set.addLabels(line);
        } else if (prefix.equals("##")) {
          set.addAttribute(line);
        } else {
          set.addInstance(line);
        }
      }
      in.close();
    } catch (Exception e) {
      e.printStackTrace();
      System.exit(-1);
    }


    return set;
  }
}
