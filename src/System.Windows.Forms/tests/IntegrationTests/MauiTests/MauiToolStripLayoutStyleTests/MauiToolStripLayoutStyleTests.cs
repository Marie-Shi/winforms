// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;
using System.Windows.Forms.IntegrationTests.Common;
using ReflectTools;
using WFCTestLib.Log;
using WFCTestLib.Util;

namespace System.Windows.Forms.IntegrationTests
{
    public class MauiToolStripLayoutStyleTests : ReflectBase
    {
        private ToolStripContainerDescription _testItem = ToolStripContainerDescription.ToolStripDescription;
        
        public MauiToolStripLayoutStyleTests(string[] args) : base(args)
        {
            this.BringToForeground();
        }
        
        public static void Main(string[] args)
        {
            Thread.CurrentThread.SetCulture("en-US");
            Application.Run(new MauiToolStripLayoutStyleTests(args));
        }

        protected override void InitTest(TParams p)
        {
            base.InitTest(p);
        }
           
        [Scenario(true)]
        public ScenarioResult Dock_Top_Layout_Auto(TParams p)
        {
            ScenarioResult scr = new ScenarioResult();
            Controls.Clear();
            ToolStrip ts = _testItem.CreateRandom(p.ru, this, p.ru.GetRange(1, 10));

            ManualFreeze();
            scr.IncCounters(ToolStripUtil.IsDockValid(this, ts, DockStyle.Top), "FAIL: ToolStrip did not dock top", p.log);
            scr.IncCounters(ts.LayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow, "FAIL: Auto LayoutStyle was not horizontal for top-docked bar", p.log);
            return scr;
        }
        
        [Scenario(true)]
        public ScenarioResult Dock_Top_Layout_Horizontal(TParams p)
        {
            ScenarioResult scr = new ScenarioResult();
            Controls.Clear();
            ToolStrip ts = _testItem.CreateRandom(p.ru, this, p.ru.GetRange(1, 10));
           
            ts.Dock = DockStyle.Top;
            ts.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            p.log.WriteLine("DockStyle is set to Horizontal");
            
            ManualFreeze();
            scr.IncCounters(ToolStripUtil.IsDockValid(this, ts, DockStyle.Top), "FAIL: ToolStrip did not dock top", p.log);
            scr.IncCounters(ts.LayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow, "FAIL: Horizontal LayoutStyle was not horizontal for top-docked bar", p.log);
            return scr;
        }
              
        [Scenario(true)]
        public ScenarioResult Dock_Top_Layout_Vertical(TParams p)
        {
            ScenarioResult scr = new ScenarioResult();
            Controls.Clear();
            ToolStrip ts = _testItem.CreateRandom(p.ru, this, p.ru.GetRange(5, 10));
            
            ts.Dock = DockStyle.Top;
            ts.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            p.log.WriteLine("DockStyle is set to vertical");
            
            ManualFreeze();
            scr.IncCounters(ToolStripUtil.IsDockValid(this, ts, DockStyle.Top), "FAIL: ToolStrip did not dock top", p.log);
            scr.IncCounters(ts.LayoutStyle == ToolStripLayoutStyle.VerticalStackWithOverflow, "FAIL: Horizontal LayoutStyle was not horizontal for top-docked bar", p.log);
            return scr;
        }
        
        [Scenario(true)]
        public ScenarioResult Dock_Left_Layout_Auto(TParams p)
        {
            ScenarioResult scr = new ScenarioResult();
            Controls.Clear();
            ToolStrip ts = _testItem.CreateRandom(p.ru, this, p.ru.GetRange(5, 10));
            
            ts.Dock = DockStyle.Left;
            ts.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            p.log.WriteLine("DockStyle is set to auto");

            ManualFreeze();
            scr.IncCounters(ToolStripUtil.IsDockValid(this, ts, DockStyle.Left), "FAIL: ToolStrip did not dock left", p.log);
            scr.IncCounters(ts.LayoutStyle == ToolStripLayoutStyle.VerticalStackWithOverflow, "FAIL: Auto LayoutStyle was not vertical for left-docked bar", p.log);
            return scr;
        }
        
        [Scenario(true)]
        public ScenarioResult Dock_Left_Layout_Horizontal(TParams p)
        {
            ScenarioResult scr = new ScenarioResult();
            Controls.Clear();
            ToolStrip ts = _testItem.CreateRandom(p.ru, this, p.ru.GetRange(5, 10));

            ts.Dock = DockStyle.Left;
            ts.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            p.log.WriteLine("DockStyle is set to horizontal");
            
            ManualFreeze();
            scr.IncCounters(ToolStripUtil.IsDockValid(this, ts, DockStyle.Left), "FAIL: ToolStrip did not dock left", p.log);
            scr.IncCounters(ts.LayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow, "FAIL: Horizontal LayoutStyle was not horizontal for left-docked bar", p.log);
            return scr;
        }
                
        [Scenario(true)]
        public ScenarioResult Dock_Left_Layout_Vertical(TParams p)
        {
            ScenarioResult scr = new ScenarioResult();
            Controls.Clear();
            ToolStrip ts = _testItem.CreateRandom(p.ru, this, p.ru.GetRange(5, 10));

            ts.Dock = DockStyle.Left;
            ts.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            p.log.WriteLine("DockStyle is set to vertical");
           
            ManualFreeze();
            scr.IncCounters(ToolStripUtil.IsDockValid(this, ts, DockStyle.Left), "FAIL: ToolStrip did not dock top", p.log);
            scr.IncCounters(ts.LayoutStyle == ToolStripLayoutStyle.VerticalStackWithOverflow, "FAIL: Vertical LayoutStyle was not correct for left-docked bar", p.log);
            return scr;
        }
    }
}
