
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using Zuby.ADGV;
using System.Linq.Dynamic.Core;
namespace NesePlastikForms.CustomElements;
public class CustomDataGrid : AdvancedDataGridView
{
	public List<string> GizlenenSutunlar = new List<string>();
	IGridFilter filter;
	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1;
	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2;
	public CustomDataGrid() : base()
	{
		this.DataSourceChanged += CustomDataGrid_DataSourceChanged;
		this.SortStringChanged += CustomDataGrid_SortStringChanged;
		this.FilterStringChanged += CustomDataGrid_FilterStringChanged;

		dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
		dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		this.AllowUserToAddRows = true;
		this.AllowUserToDeleteRows = true;
		this.AllowUserToResizeColumns = true;
		this.AllowUserToResizeRows = true;
		this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
		this.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
		this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
		dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.DefaultCellStyle = dataGridViewCellStyle2;
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
		dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
		dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gainsboro;
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

		this.ColumnHeadersHeight = 50;
		this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

		this.EnableHeadersVisualStyles = false;
		this.GridColor = System.Drawing.SystemColors.Control;
		this.MultiSelect = true;
		this.ReadOnly = false;
		this.RowHeadersVisible = false;
		this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
		this.ShowCellToolTips = false;
		this.ShowEditingIcon = false;

	}

	private void CustomDataGrid_FilterStringChanged(object? sender, FilterEventArgs e) => filter.Filter(this);
	private void CustomDataGrid_SortStringChanged(object? sender, SortEventArgs e) => filter.Sorter(this);
	private void CustomDataGrid_DataSourceChanged(object? sender, EventArgs e) => HideColumns(GizlenenSutunlar.ToArray());
	public List<T> ConvertListedRowsToList<T>()
	{
		var list = new List<T>();
		foreach (DataGridViewRow row in this.Rows)
		{
			{
				var item = row.DataBoundItem;
				if (item != null)
				{
					list.Add((T)item);
				}
			}
		}
		return list;
	}

	public string GetCellValue(DataGridViewRow row, string columnName)
	{
		return row.Cells[GetColumnIndexByName(columnName)].Value.ToString();
	}
	private void HideColum(int index)
	{
		if (index != -1)
			this.Columns[index].Visible = false;
	}
	public void HideColumns(params int[] indexes)
	{
		foreach (var index in indexes)
		{
			HideColum(index);
		}
	}
	public void HideColumns(params string[] names)
	{
		foreach (var name in names)
		{
			if (!GizlenenSutunlar.Contains(name))
				GizlenenSutunlar.Add(name);
			if (GetColumnIndexByName(name) != -1)
				HideColum(this.Columns[name].Index);
		}
	}
	public void ShowColumns(params string[] names)
	{
		foreach (var name in names)
		{
			if (GizlenenSutunlar.Contains(name))
				GizlenenSutunlar.Remove(name);
			this.Columns[name].Visible = true;
		}
	}
	public int GetColumnIndexByName(string ColumnName)
	{
		for (int i = 0; i < this.Columns.Count; i++)
		{
			DataGridViewColumn item = this.Columns[i];
			if (item.Name == ColumnName) return i;
		}
		return -1;
	}
	class Anonym
	{
		public string StringColumn { get; set; }
	}
	public void SetData<T>(IEnumerable<T> list) where T : class
	{
		List<Anonym> listYerel = new();
		list = list.ToList();
		if (list is List<string>)
		{
			foreach (var item in list)
			{
				if (item != null)
					listYerel.Add(new Anonym() { StringColumn = item.ToString() });
			}
			this.DataSource = listYerel.ToList();

			this.filter = new GridFilter<Anonym>(listYerel);

		}
		else
		{
			this.DataSource = list.ToList();
			this.filter = new GridFilter<T>(list);
		}
	}
	public interface IGridFilter
	{
		public void Sorter(AdvancedDataGridView view);
		public void Filter(AdvancedDataGridView view);

	}

	public class GridFilter<T> : IGridFilter
	{
		public GridFilter(IEnumerable<T> list)
		{
			this.SourceList = list;
		}
		public IEnumerable<T>? SourceList { get; set; }
		public IEnumerable<T>? FilterList { get; set; }
		public void Sorter(AdvancedDataGridView view)
		{
			try
			{
				if (string.IsNullOrEmpty(view.SortString) == true)
					return;

				var sortStr = view.SortString.Replace("[", "").Replace("]", "");

				if (string.IsNullOrEmpty(view.FilterString) == true)
				{
					// the grid is not filtered!
					SourceList = SourceList.AsQueryable().OrderBy(sortStr).ToList();
					view.DataSource = SourceList;
				}
				else
				{
					// the grid is filtered!
					FilterList = FilterList.AsQueryable().OrderBy(sortStr).ToList();
					view.DataSource = FilterList;
				}
			}
			catch (Exception ex)
			{
				// Log.Error(ex, MethodBase.GetCurrentMethod().Name);
			}
		}
		public void Filter(AdvancedDataGridView view)
		{
			try
			{
				if (string.IsNullOrEmpty(view.FilterString))
				{
					FilterList = SourceList;
				}
				else
				{
					FilterList = FilterAndSortDataStr(SourceList, view.FilterString, view.SortString);
				}
				view.DataSource = FilterList;
			}
			catch (Exception ex)
			{
				// Log.Error(ex, MethodBase.GetCurrentMethod().Name);
			}
		}
		private List<T> FilterAndSortDataStr(IEnumerable<T> collection, string filter, string sort)
		{
			if (collection == null)
			{
				return new List<T>();
			}

			if (string.IsNullOrWhiteSpace(filter) && string.IsNullOrWhiteSpace(sort))
			{
				return collection.ToList();
			}

			var table = new DataTable
			{
				CaseSensitive = false

			};

			var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(prop => !Attribute.IsDefined(prop, typeof(IgnoreDataMemberAttribute)))
				.ToList();

			table.Columns.AddRange(props.Select(p =>
			new DataColumn(p.Name, Nullable.GetUnderlyingType(
			p.PropertyType) ?? p.PropertyType)).ToArray());

			table.Columns.Add(new DataColumn { DataType = typeof(int) });

			var itemList = collection.ToArray();
			var count = itemList.Length;
			for (var i = 0; i < count; i++)
			{
				var data = new object[props.Count + 1];
				var dataItems = props.Select(p => p.GetValue(itemList[i], null)).ToArray();

				for (var z = 0; z < props.Count; z++)
				{
					data[z] = dataItems[z];
				}

				data[props.Count] = i;
				table.Rows.Add(data);
			}

			DataRow[] rows = null;

			try
			{
				var dv = table.DefaultView;
				dv.RowFilter = filter ?? string.Empty;
				dv.Sort = sort ?? string.Empty;
				rows = dv.ToTable().Rows.Cast<DataRow>().ToArray();
			}
			catch (EvaluateException) { }

			var result = new List<T>();
			if (rows != null)
			{
				var indexes = rows.Select(r => (int)r[table.Columns.Count - 1]).ToArray();

				for (var i = 0; i < count; i++)
				{
					if (indexes.Contains(i))
					{
						result.Add(itemList[i]);
					}
				}
			}

			return result;

		}

	}

}
