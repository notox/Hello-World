#include <stdio.h>
#include "list.h"

void
PrintList( const List L )
{
    Position P = Header( L );

    if( IsEmpty( L ) )
        printf( "Empty list\n" );
    else
    {
        do
        {
            P = Advance( P );
            printf( "%d ", Retrieve( P ) );
        } while( !IsLast( P, L ) );
        printf( "\n" );
    }
}

main( )
{
    List L;
    Position P;
    int i;

    L = MakeEmpty( NULL );
    P = Header( L );
    PrintList( L );

    for( i = 0; i < 10; i++ )
    {
        Insert( i, L, P );
        PrintList( L );
        P = Advance( P );
    }
    for( i = 0; i < 10; i+= 2 )
        Delete( i, L );

    for( i = 0; i < 10; i++ )
        if( ( i % 2 == 0 ) == ( Find( i, L ) != NULL ) )
            printf( "Find fails\n" );

    printf( "Finished deletions\n" );

    PrintList( L );

	Reverse(L);
	PrintList(L);

    DeleteList( L );

	getchar();

    return 0;
}

maintest()
{
	List L;
	Position P;
	int i;

	L = MakeEmpty( NULL );
	P = Header( L );
	PrintList( L );

	for( i = 0; i < 10; i++ )
	{
		Insert( i, L, P );
		PrintList( L );
		P = Advance( P );
	}
	//InsertNode(First(L), P);
	printf(LoopExisted(L) == 1 ?"Found":"NotFound");

	getchar();
	return 0;
}
