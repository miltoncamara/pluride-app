using FormsToolkit.iOS;
using Pluride.App.iOS.Renderers;
using Pluride.App.Portable.Cells;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListViewCellArrow), typeof(ListViewCellRenderer))]
namespace Pluride.App.iOS.Renderers
{
    public class ListViewCellRenderer : TextCellRenderer
    {
        public static void Init()
        {
            var test = DateTime.UtcNow;
        }

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {

            var tvc = reusableCell as CellTableViewCell;
            if (tvc == null)
            {
                tvc = new CellTableViewCell(UITableViewCellStyle.Value1, item.GetType().FullName);
            }
            tvc.Cell = item;
            var cell = base.GetCell(item, tvc, tv);
            cell.SetDisclosure(item.StyleId);
            return cell;
        }
    }
}