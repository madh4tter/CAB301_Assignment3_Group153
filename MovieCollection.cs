// Phase 2
// An implementation of MovieCollection ADT
// 2022


using System;
using System.Collections.Generic;

//A class that models a node of a binary search tree
//An instance of this class is a node in a binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode lchild; // reference to its left child 
	private BTreeNode rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicates in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode root; // movies are stored in a binary search tree and the root of the binary search tree is 'root' 
	private int count; // the number of (different) movies currently stored in this movie collection 
	private int arrayCounter; // the number of movies that are counted during the array creation



	// get the number of movies in this movie colllection 
	// pre-condition: nil
	// post-condition: return the number of movies in this movie collection and this movie collection remains unchanged
	public int Number { get { return count; } }

	// constructor - create an object of MovieCollection object
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

	// Check if this movie collection is empty
	// Pre-condition: nil
	// Post-condition: return true if this movie collection is empty; otherwise, return false.
	public bool IsEmpty()
	{
		//Finds if the root is null and if so the BTree is empty
		if (root == null)
        {
			return true;
        }
        else
        {
			return false;
        }
	}

	// Insert a movie into this movie collection
	// Pre-condition: nil
	// Post-condition: the movie has been added into this movie collection and return true, if the movie is not in this movie collection; otherwise, the movie has not been added into this movie collection and return false.
	public bool Insert(IMovie movie)
	{
		//If the root is null it adds the movie as the root, if not and if it is not in the tree already it adds it alphabetically
		if (root == null)
		{
			root = new BTreeNode(movie);
			count++;
			return true;
		}
		else
		{
			bool searchResult = Search(movie);

			if (searchResult != true)
			{
				Insert(movie, root);
				count++;
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	private void Insert(IMovie movie, BTreeNode ptr)
    {
		//Finds the correct alphabetical placement for the object then inserts it into the tree
		if (movie.CompareTo(ptr.Movie) < 0)
		{
			if (ptr.LChild == null)
            {
				ptr.LChild = new BTreeNode(movie);
			}
			else
            {
				Insert(movie, ptr.LChild);
			}
		}
		else
		{
			if (ptr.RChild == null)
            {
				ptr.RChild = new BTreeNode(movie);
			}
			else
            {
				Insert(movie, ptr.RChild);
			}
				
		}
	}


	// Delete a movie from this movie collection
	// Pre-condition: nil
	// Post-condition: the movie is removed out of this movie collection and return true, if it is in this movie collection; return false, if it is not in this movie collection
	public bool Delete(IMovie movie)
	{
		//Searches through the tree until it finds the movie object.
		BTreeNode ptr = root;
		BTreeNode parent = null; 

		while ((ptr != null) && (movie.CompareTo(ptr.Movie) != 0))
		{
			parent = ptr;
			if (movie.CompareTo(ptr.Movie) < 0)
            {
				ptr = ptr.LChild;
			}
			else
            {
				ptr = ptr.RChild;

			}
		}

		// if the search was successful it deletes the node and moves all the other lower nodes accordingly
		if (ptr != null) 
		{
			count--;
			if ((ptr.LChild != null) && (ptr.RChild != null))
			{
				if (ptr.LChild.RChild == null) 
				{
					ptr.Movie = ptr.LChild.Movie;
					ptr.LChild = ptr.LChild.LChild;
				}
				else
				{
					BTreeNode p = ptr.LChild;
					BTreeNode pp = ptr;
					while (p.RChild != null)
					{
						pp = p;
						p = p.RChild;
					}

					ptr.Movie = p.Movie;
					pp.RChild = p.LChild;
				}
			}
			else
			{
				BTreeNode c;
				if (ptr.LChild != null)
                {
					c = ptr.LChild;
				}
				else
                {
					c = ptr.RChild;
				}

				if (ptr == root)
                {
					root = c;
				}
				else
				{
					if (ptr == parent.LChild)
                    {
						parent.LChild = c;
					}
					else
                    {
						parent.RChild = c;
					}
				}
			}
			return true;
		}
		return false;
	}

	// Search for a movie in this movie collection
	// pre: nil
	// post: return true if the movie is in this movie collection;
	//	     otherwise, return false.
	public bool Search(IMovie movie)
	{
		return Search(movie, root);
	}

	private bool Search(IMovie movie, BTreeNode ptr)
    {
		//Searches the BTree via IMovie object,moving through the tree and if it doesn't find it then it returns false
		if (ptr != null)
		{
			if (movie.CompareTo(ptr.Movie) == 0)
			{
				return true;
			}
			else if (movie.CompareTo(ptr.Movie) < 0)
			{
				return Search(movie, ptr.LChild);
			}
			else
			{
				return Search(movie, ptr.RChild);
			}
		}
		else
		{
			return false;
		}
	}

	// Search for a movie by its title in this movie collection  
	// pre: nil
	// post: return the reference of the movie object if the movie is in this movie collection;
	//	     otherwise, return null.
	public IMovie Search(string movietitle)
	{
		return Search(movietitle, root);
	}

	private IMovie Search(string movieTitle, BTreeNode ptr)
    {
		//Searches the BTree via string ,moving through the tree and if it doesn't find it then it returns false
		if (ptr != null)
		{
			if (movieTitle.CompareTo(ptr.Movie.Title) == 0)
			{
				return ptr.Movie;
			}
			else if (movieTitle.CompareTo(ptr.Movie.Title) < 0)
			{
				return Search(movieTitle, ptr.LChild);
			}
			else
			{
				return Search(movieTitle, ptr.RChild);
			}
		}
		else
		{
			return null;
		}
	}

	
	// Store all the movies in this movie collection in an array in the dictionary order by their titles
	// Pre-condition: nil
	// Post-condition: return an array of movies that are stored in dictionary order by their titles
	public IMovie[] ToArray()
	{
		//Creates an Array with the size of how many movies there are then adds them to an array through PreOrderTravarse then sorts the array
		IMovie[] movies = new IMovie[count];
		arrayCounter = 0;
		PreOrderTravarseAdd(root, movies);
		
		// Sort Array
		int min;
		IMovie temp;
		for (int i = 0; i <= (count - 2); i++)
		{
			min = i;
			for (int j = (i + 1); j <= (count - 1); j++)
			{
				if (movies[j].CompareTo(movies[min]) == -1)
				{
					min = j;
				}
			}
			temp = movies[i];
			movies[i] = movies[min];
			movies[min] = temp;
		}
		
		return movies;
	}

	private void PreOrderTravarseAdd(BTreeNode r, IMovie[] movies)
    {
		//PreOrderTravarse through the BTree and add it to the array
		if(r != null)
        {
			AddToArray(r, movies);
			PreOrderTravarseAdd(r.LChild, movies);
			PreOrderTravarseAdd(r.RChild, movies);
        }
    }

	private void AddToArray(BTreeNode r, IMovie[] movies)
    { 
		//Adds a movie object to an array
		movies[arrayCounter] = r.Movie;
		arrayCounter++;
	}

	// Clear this movie collection
	// Pre-condotion: nil
	// Post-condition: all the movies have been removed from this movie collection 
	public void Clear()
	{
		//Clears the root and clears the count
		root = null;
		count = 0;
	}
}





