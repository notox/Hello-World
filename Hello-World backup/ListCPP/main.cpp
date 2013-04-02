#include <iostream>

struct Node{
    int data;
    Node* next;
};

int existLoop(Node* head)
{
    Node* slow = head;
    Node* fast = head;
    while (fast = fast->next)
    {
        if (fast == slow)
            return 1;
        slow = slow->next;
        fast = fast->next;
        if (!fast)
            break;
    }
    return 0;
}

int testmain()
{
    Node *n1 = new Node;
    Node *n2 = new Node;
    Node *n3 = new Node;

    n1->next = n2;
    n2->next = n3;
    n3->next = n3;

    if (existLoop(n1))
        printf("There is a loop.");

    int c;
    c = getchar();

    return 0;
}