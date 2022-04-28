using System;
using System.Collections.Generic;
using System.Linq;
using SweepingBlade.Collections.Generic;

namespace SweepingBlade.Linq;

public static class ReadOnlyTreeNodeExtensions
{
    public static T Find<T>(this T root, Func<T, IEnumerable<T>> childrenSelector, Func<T, bool> matchSelector) where T : IReadOnlyTreeNode<T>
    {
        return FindAll(root, childrenSelector, matchSelector).First();
    }

    public static T Find<T>(this IEnumerable<T> elements, Func<T, IEnumerable<T>> childrenSelector, Func<T, bool> matchSelector) where T : IReadOnlyTreeNode<T>
    {
        return FindAll(elements, childrenSelector, matchSelector).First();
    }

    public static IEnumerable<T> FindAll<T>(this T root, Func<T, IEnumerable<T>> childrenSelector, Func<T, bool> matchSelector) where T : IReadOnlyTreeNode<T>
    {
        return Flatten(root, childrenSelector).Where(matchSelector);
    }

    public static IEnumerable<T> FindAll<T>(this IEnumerable<T> elements, Func<T, IEnumerable<T>> childrenSelector, Func<T, bool> matchSelector) where T : IReadOnlyTreeNode<T>
    {
        return Flatten(elements, childrenSelector).Where(matchSelector);
    }

    public static T FindOrDefault<T>(this IEnumerable<T> elements, Func<T, IEnumerable<T>> childrenSelector, Func<T, bool> matchSelector) where T : IReadOnlyTreeNode<T>
    {
        return FindAll(elements, childrenSelector, matchSelector).FirstOrDefault();
    }

    public static T FindParent<T>(this T node, Func<T, bool> matchSelector) where T : IReadOnlyTreeNode<T>
    {
        if (node is null) throw new ArgumentNullException(nameof(node));

        while (node is not null)
        {
            if (matchSelector(node))
            {
                return node;
            }

            node = node.Parent;
        }

        throw new ArgumentOutOfRangeException(nameof(matchSelector), "Could not find parent");
    }

    public static IEnumerable<T> Flatten<T>(this IEnumerable<T> elements, Func<T, IEnumerable<T>> childrenSelector) where T : IReadOnlyTreeNode<T>
    {
        var stack = new Stack<T>();

        foreach (var element in elements)
        {
            stack.Push(element);
        }

        while (stack.Any())
        {
            var currentNode = stack.Pop();
            yield return currentNode;

            foreach (var child in childrenSelector(currentNode))
            {
                stack.Push(child);
            }
        }
    }

    public static IEnumerable<T> Flatten<T>(this T root, Func<T, IEnumerable<T>> childrenSelector) where T : IReadOnlyTreeNode<T>
    {
        yield return root;

        var stack = new Stack<T>();

        foreach (var child in childrenSelector(root))
        {
            stack.Push(child);
        }

        while (stack.Any())
        {
            var currentNode = stack.Pop();
            yield return currentNode;

            foreach (var child in childrenSelector(currentNode))
            {
                stack.Push(child);
            }
        }
    }

    public static TNode Get<TNode, TValue>(this IEnumerable<TNode> elements, DoublyLinkedListNode<TValue> currentNode, Func<TNode, TValue, bool> selector) where TNode : IReadOnlyTreeNode<TNode>
    {
        var root = elements.First(element => selector(element, currentNode.Value));

        currentNode = currentNode.Next;
        while (currentNode is not null)
        {
            root = root.Nodes.First(element => selector(element, currentNode.Value));
            currentNode = currentNode.Next;
        }

        return root;
    }

    public static void Walk<T>(this T root, Func<T, IEnumerable<T>> childrenSelector, Action<T, T> action) where T : IReadOnlyTreeNode<T>
    {
        var stack = new Stack<T>();

        foreach (var child in childrenSelector(root))
        {
            stack.Push(child);
            action(root, child);
        }

        while (stack.Any())
        {
            var currentNode = stack.Pop();

            foreach (var child in childrenSelector(currentNode))
            {
                stack.Push(child);
                action(currentNode, child);
            }
        }
    }
}