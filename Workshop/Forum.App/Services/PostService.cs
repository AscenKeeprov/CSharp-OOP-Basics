using System.Collections.Generic;
using System.Linq;
using Forum.Data;
using Forum.Models;
using Forum.App.UserInterface.ViewModels;
using System;

namespace Forum.App.Services
{
    public class PostService
    {
	public static string[] GetAllCategoryNames()
	{
	    ForumData forumData = new ForumData();
	    string[] allCategories = forumData.Categories.Select(c => c.Name).ToArray();
	    return allCategories;
	}

	public static Category GetCategory(int categoryId)
	{
	    ForumData forumData = new ForumData();
	    Category category = forumData.Categories.Find(c => c.Id == categoryId);
	    return category;
	}

	public static IEnumerable<Post> GetPostsByCategory(int categoryId)
	{
	    ForumData forumData = new ForumData();
	    ICollection<int> postIds = forumData.Categories.First(c => c.Id == categoryId).PostIds;
	    IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));
	    return posts;
	}

	public static IList<ReplyViewModel> GetPostReplies(int postId)
	{
	    ForumData forumData = new ForumData();
	    Post post = forumData.Posts.Find(p => p.Id == postId);
	    IList<ReplyViewModel> replies = new List<ReplyViewModel>();
	    foreach (int replyId in post.ReplyIds)
	    {
		Reply reply = forumData.Replies.Find(r => r.Id == replyId);
		replies.Add(new ReplyViewModel(reply));
	    }
	    return replies;
	}

	public static PostViewModel GetPostViewModel(int postId)
	{
	    ForumData forumData = new ForumData();
	    Post post = forumData.Posts.Find(p => p.Id == postId);
	    PostViewModel postViewModel = new PostViewModel(post);
	    return postViewModel;
	}

	private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
	{
	    var categoryName = postView.Category;
	    Category category = forumData.Categories.FirstOrDefault(c => c.Name == categoryName);
	    if (category == null)
	    {
		List<Category> categories = forumData.Categories;
		int categoryId = categories.LastOrDefault()?.Id + 1 ?? 1;
		category = new Category(categoryId, categoryName);
		forumData.Categories.Add(category);
		forumData.SaveChanges();
	    }
	    return category;
	}

	public static bool TrySavePost(PostViewModel postView)
	{
	    bool isCategoryEmpty = String.IsNullOrWhiteSpace(postView.Category);
	    bool isTitleEmpty = String.IsNullOrWhiteSpace(postView.Title);
	    bool isContentEmpty = !postView.Content.Any();
	    if (isCategoryEmpty || isTitleEmpty || isContentEmpty) return false;
	    ForumData forumData = new ForumData();
	    Category category = EnsureCategory(postView, forumData);
	    int postId = forumData.Posts.LastOrDefault()?.Id + 1 ?? 1;
	    User author = UserService.GetUser(postView.Author);
	    int authorId = author.Id;
	    string content = String.Join("", postView.Content);
	    Post post = new Post(postId, postView.Title, content, category.Id, authorId);
	    forumData.Posts.Add(post);
	    author.PostIds.Add(postId);
	    category.PostIds.Add(postId);
	    forumData.SaveChanges();
	    postView.PostId = postId;
	    return true;
	}

	public static bool TrySaveReply(ReplyViewModel replyView)
	{
	    bool isContentEmpty = !replyView.Content.Any();
	    if (isContentEmpty) return false;
	    ForumData forumData = new ForumData();
	    int replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
	    string content = String.Join("", replyView.Content);
	    User author = UserService.GetUser(replyView.Author);
	    int authorId = author.Id;
	    int postId = replyView.PostId;
	    Post post = forumData.Posts.Find(p => p.Id == postId);
	    Reply reply = new Reply(replyId, content, authorId, postId);
	    forumData.Replies.Add(reply);
	    post.ReplyIds.Add(replyId);
	    forumData.SaveChanges();
	    replyView.ReplyId = replyId;
	    return true;
	}
    }
}
