namespace PMS.Models
{
	public static class GroupRepository
	{
		private static List<Group> _groups = new List<Group>() 
		{
			new Group { GroupId = 1,Name="Diabetes"},
			new Group { GroupId = 2,Name="Generic Medicine"},
			new Group { GroupId = 3,Name="Pressure"},
			new Group { GroupId = 4,Name="Kidney"},
		};
		public static void AddGroup(Group group)
		{
			var maxId=_groups.Max(g => g.GroupId);
			maxId = maxId + 1;
			_groups.Add(group);
		}
		public static List<Group> GetGroups()=>_groups;
		public static Group? GetGroupById(int id)
		{
			var group = _groups.FirstOrDefault(x => x.GroupId == id);
			if (group != null)
			{
				return new Group { GroupId = group.GroupId, Name = group.Name };
			}
			return null;
		}
		public static void UpdateGroupById(int id, Group group)
		{
			if (id != group.GroupId) return;
			var groupToUpdate = _groups.FirstOrDefault(x=>x.GroupId==id);
			if(groupToUpdate != null)
			{
				groupToUpdate.Name=group.Name;
			}
		}
		public static void DeleteGroupById(int id)
		{
			var group = _groups.FirstOrDefault(x=> x.GroupId==id);
			if(group != null)
			{
				_groups.Remove(group);
			}
		}
	}
}
