import java.util.ArrayList;
import java.util.List;

/**
 * Possible class for internal organization of a decision tree. Included to show standardized output
 * method, print().
 * 
 * Do not modify. If you use, create child class DecTreeNodeImpl that inherits the methods.
 * 
 */
public class DecTreeNode {
  String label; // for
  String attribute;
  String parentAttributeValue; // if is the root, set to null
  boolean terminal;
  List<DecTreeNode> children;

  DecTreeNode(String _label, String _attribute, String _parentAttributeValue, boolean _terminal) {
    label = _label;
    attribute = _attribute;
    parentAttributeValue = _parentAttributeValue;
    terminal = _terminal;
    if (_terminal) {
      children = null;
    } else {
      children = new ArrayList<DecTreeNode>();
    }
  }

  /**
   * Add child to the node.
   * 
   * For printing to be consistent, children should be added in order of the attribute values as
   * specified in the dataset.
   */
  public void addChild(DecTreeNode child) {
    if (children != null) {
      children.add(child);
    }
  }
}
