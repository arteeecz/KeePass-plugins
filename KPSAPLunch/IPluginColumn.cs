/*
	(C) 2023 David Suchopar
*/

using KeePassLib;

namespace KPSAPLunch
{
    public interface IPluginColumn
    {
        string GetContent(PwEntry entry);
        string GetName();
        string GetTitle();
        bool HasAction();
        void PerformAction(PwEntry entry);
    }
}