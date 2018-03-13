namespace Forum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.Data;
    using Forum.Models;
    using Forum.App.UserInterface.ViewModels;
    using System;
    using static Forum.App.Controllers.AddPostController;
    using static Forum.App.Controllers.AddReplyController;

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

	public static IEnumerable<Post> GetPostsByCategory(string categoryName)
	{
	    ForumData forumData = new ForumData();
	    ICollection<int> postIds = forumData.Categories.First(c => c.Name == categoryName).PostIds;
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

	public static PostViewModel GetPostViewModel(string postTitle)
	{
	    ForumData forumData = new ForumData();
	    Post post = forumData.Posts.Find(p => p.Title == postTitle);
	    PostViewModel postViewModel = new PostViewModel(post);
	    return postViewModel;
	}

	public static AddPostStatus TrySavePost(PostViewModel postViewModel)
	{
	    if (String.IsNullOrWhiteSpace(postViewModel.Title) ||
		postViewModel.Title.Length < 4 || postViewModel.Title.Length > 64)
		return AddPostStatus.TitleError;
	    if (String.IsNullOrWhiteSpace(postViewModel.Category) ||
		postViewModel.Category.Length < 4 || postViewModel.Category.Length > 32)
		return AddPostStatus.CategoryError;
	    if (!postViewModel.Content.Any()) return AddPostStatus.ContentError;
	    ForumData forumData = new ForumData();
	    Category category = EnsureCategory(postViewModel, forumData);
	    int postId = forumData.Posts.LastOrDefault()?.Id + 1 ?? 1;
	    User author = forumData.Users.Find(u => u.Username == postViewModel.Author);
	    string content = String.Join("", postViewModel.Content);
	    Post post = new Post(postId, postViewModel.Title, content, category.Id, author.Id);
	    forumData.Posts.Add(post);
	    author.PostIds.Add(postId);
	    category.PostIds.Add(postId);
	    forumData.SaveChanges();
	    postViewModel.PostId = postId;
	    return AddPostStatus.Success;
	}

	private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
	{
	    var categoryName = postView.Category;
	    Category category = forumData.Categories.FirstOrDefault(c => c.Name == categoryName);
	    if (category == null)
	    {
		int categoryId = forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;
		category = new Category(categoryId, categoryName);
		forumData.Categories.Add(category);
		forumData.SaveChanges();
	    }
	    return category;
	}

	public static AddReplyStatus TrySaveReply(ReplyViewModel replyView)
	{
	    if (!replyView.Content.Any()) return AddReplyStatus.ContentError;
	    ForumData forumData = new ForumData();
	    int replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
	    string content = String.Join("", replyView.Content);
	    User author = forumData.Users.Find(u => u.Username == replyView.Author);
	    string postTitle = replyView.PostTitle;
	    Post post = forumData.Posts.Find(p => p.Title == postTitle);
	    Reply reply = new Reply(replyId, content, author.Id, post.Id);
	    forumData.Replies.Add(reply);
	    post.ReplyIds.Add(replyId);
	    forumData.SaveChanges();
	    replyView.ReplyId = replyId;
	    return AddReplyStatus.Success;
	}
    }
}
