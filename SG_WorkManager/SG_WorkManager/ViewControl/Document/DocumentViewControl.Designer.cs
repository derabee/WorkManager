namespace SG_WorkManager
{
    partial class DocumentViewControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("실행품의");
            TreeNode treeNode2 = new TreeNode("차량운행일지");
            TreeNode treeNode3 = new TreeNode("업무용지출구매청구서");
            TreeNode treeNode4 = new TreeNode("발주서-구매서");
            TreeNode treeNode5 = new TreeNode("자기개발계획서");
            TreeNode treeNode6 = new TreeNode("즐겨찾기", new TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4, treeNode5 });
            TreeNode treeNode7 = new TreeNode("1_C.Comon");
            TreeNode treeNode8 = new TreeNode("2_O.Overall_GA");
            TreeNode treeNode9 = new TreeNode("3_D.Document");
            TreeNode treeNode10 = new TreeNode("4_I.Information");
            TreeNode treeNode11 = new TreeNode("zD.Gen", new TreeNode[] { treeNode7, treeNode8, treeNode9, treeNode10 });
            TreeNode treeNode12 = new TreeNode("C.Common");
            TreeNode treeNode13 = new TreeNode("E.Estimate");
            TreeNode treeNode14 = new TreeNode("P.Purchase");
            TreeNode treeNode15 = new TreeNode("T.Technique");
            TreeNode treeNode16 = new TreeNode("zE.Pro", new TreeNode[] { treeNode12, treeNode13, treeNode14, treeNode15 });
            TreeNode treeNode17 = new TreeNode("zY.Guest");
            TreeNode treeNode18 = new TreeNode("신동빈주임");
            TreeNode treeNode19 = new TreeNode("zZ.Temp", new TreeNode[] { treeNode18 });
            panel1 = new Panel();
            panel3 = new Panel();
            treeView1 = new TreeView();
            panel6 = new Panel();
            txbNodeText = new TextBox();
            panel5 = new Panel();
            btnAddRootNode = new Button();
            btnAddNode = new Button();
            btnEditNode = new Button();
            btnDeleteNode = new Button();
            panel4 = new Panel();
            btnMoveNodePre = new Button();
            btnMoveNodeNext = new Button();
            btnMoveNodeUp = new Button();
            btnMoveNodeDown = new Button();
            btnEnableMoveNode = new Button();
            panel2 = new Panel();
            pnlFinalNodeEdit = new Panel();
            btnFolderDialog = new Button();
            lblSelectedNode = new Label();
            label1 = new Label();
            btnSaveNodePath = new Button();
            txbNodePath = new TextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            pnlFinalNodeEdit.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20, 10, 20, 10);
            panel1.Size = new Size(571, 850);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(treeView1);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(20, 10);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(531, 830);
            panel3.TabIndex = 1;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(10, 10);
            treeView1.Name = "treeView1";
            treeNode1.Name = "노드14";
            treeNode1.Text = "실행품의";
            treeNode2.Name = "노드15";
            treeNode2.Text = "차량운행일지";
            treeNode3.Name = "노드16";
            treeNode3.Text = "업무용지출구매청구서";
            treeNode4.Name = "노드17";
            treeNode4.Text = "발주서-구매서";
            treeNode5.Name = "노드18";
            treeNode5.Text = "자기개발계획서";
            treeNode6.Name = "노드0";
            treeNode6.Text = "즐겨찾기";
            treeNode7.Name = "노드10";
            treeNode7.Text = "1_C.Comon";
            treeNode8.Name = "노드11";
            treeNode8.Text = "2_O.Overall_GA";
            treeNode9.Name = "노드12";
            treeNode9.Text = "3_D.Document";
            treeNode10.Name = "노드13";
            treeNode10.Text = "4_I.Information";
            treeNode11.Name = "노드1";
            treeNode11.Text = "zD.Gen";
            treeNode12.Name = "노드5";
            treeNode12.Text = "C.Common";
            treeNode13.Name = "노드6";
            treeNode13.Text = "E.Estimate";
            treeNode14.Name = "노드7";
            treeNode14.Text = "P.Purchase";
            treeNode15.Name = "노드8";
            treeNode15.Text = "T.Technique";
            treeNode16.Name = "노드2";
            treeNode16.Text = "zE.Pro";
            treeNode17.Name = "노드3";
            treeNode17.Text = "zY.Guest";
            treeNode18.Name = "노드9";
            treeNode18.Text = "신동빈주임";
            treeNode19.Name = "노드4";
            treeNode19.Text = "zZ.Temp";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode6, treeNode11, treeNode16, treeNode17, treeNode19 });
            treeView1.Size = new Size(511, 702);
            treeView1.TabIndex = 19;
            // 
            // panel6
            // 
            panel6.Controls.Add(txbNodeText);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(10, 712);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(3);
            panel6.Size = new Size(511, 36);
            panel6.TabIndex = 18;
            // 
            // txbNodeText
            // 
            txbNodeText.Dock = DockStyle.Fill;
            txbNodeText.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNodeText.Location = new Point(3, 3);
            txbNodeText.Name = "txbNodeText";
            txbNodeText.Size = new Size(505, 29);
            txbNodeText.TabIndex = 19;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnAddRootNode);
            panel5.Controls.Add(btnAddNode);
            panel5.Controls.Add(btnEditNode);
            panel5.Controls.Add(btnDeleteNode);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(10, 748);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(3);
            panel5.Size = new Size(511, 36);
            panel5.TabIndex = 17;
            // 
            // btnAddRootNode
            // 
            btnAddRootNode.BackColor = SystemColors.Control;
            btnAddRootNode.Dock = DockStyle.Right;
            btnAddRootNode.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddRootNode.Location = new Point(4, 3);
            btnAddRootNode.Name = "btnAddRootNode";
            btnAddRootNode.Size = new Size(126, 30);
            btnAddRootNode.TabIndex = 24;
            btnAddRootNode.Text = "루트 노드 추가";
            btnAddRootNode.UseVisualStyleBackColor = false;
            // 
            // btnAddNode
            // 
            btnAddNode.BackColor = SystemColors.Control;
            btnAddNode.Dock = DockStyle.Right;
            btnAddNode.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddNode.Location = new Point(130, 3);
            btnAddNode.Name = "btnAddNode";
            btnAddNode.Size = new Size(126, 30);
            btnAddNode.TabIndex = 23;
            btnAddNode.Text = "하위 노드 추가";
            btnAddNode.UseVisualStyleBackColor = false;
            // 
            // btnEditNode
            // 
            btnEditNode.BackColor = SystemColors.Control;
            btnEditNode.Dock = DockStyle.Right;
            btnEditNode.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditNode.Location = new Point(256, 3);
            btnEditNode.Name = "btnEditNode";
            btnEditNode.Size = new Size(126, 30);
            btnEditNode.TabIndex = 16;
            btnEditNode.Text = "노드명 변경";
            btnEditNode.UseVisualStyleBackColor = false;
            // 
            // btnDeleteNode
            // 
            btnDeleteNode.BackColor = SystemColors.Control;
            btnDeleteNode.Dock = DockStyle.Right;
            btnDeleteNode.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteNode.Location = new Point(382, 3);
            btnDeleteNode.Name = "btnDeleteNode";
            btnDeleteNode.Size = new Size(126, 30);
            btnDeleteNode.TabIndex = 13;
            btnDeleteNode.Text = "삭제";
            btnDeleteNode.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnMoveNodePre);
            panel4.Controls.Add(btnMoveNodeNext);
            panel4.Controls.Add(btnMoveNodeUp);
            panel4.Controls.Add(btnMoveNodeDown);
            panel4.Controls.Add(btnEnableMoveNode);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(10, 784);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3);
            panel4.Size = new Size(511, 36);
            panel4.TabIndex = 14;
            // 
            // btnMoveNodePre
            // 
            btnMoveNodePre.BackColor = SystemColors.Control;
            btnMoveNodePre.Dock = DockStyle.Right;
            btnMoveNodePre.Enabled = false;
            btnMoveNodePre.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnMoveNodePre.Location = new Point(5, 3);
            btnMoveNodePre.Name = "btnMoveNodePre";
            btnMoveNodePre.Size = new Size(87, 30);
            btnMoveNodePre.TabIndex = 28;
            btnMoveNodePre.Text = "Pre";
            btnMoveNodePre.UseVisualStyleBackColor = false;
            // 
            // btnMoveNodeNext
            // 
            btnMoveNodeNext.BackColor = SystemColors.Control;
            btnMoveNodeNext.Dock = DockStyle.Right;
            btnMoveNodeNext.Enabled = false;
            btnMoveNodeNext.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnMoveNodeNext.Location = new Point(92, 3);
            btnMoveNodeNext.Name = "btnMoveNodeNext";
            btnMoveNodeNext.Size = new Size(87, 30);
            btnMoveNodeNext.TabIndex = 27;
            btnMoveNodeNext.Text = "Next";
            btnMoveNodeNext.UseVisualStyleBackColor = false;
            // 
            // btnMoveNodeUp
            // 
            btnMoveNodeUp.BackColor = SystemColors.Control;
            btnMoveNodeUp.Dock = DockStyle.Right;
            btnMoveNodeUp.Enabled = false;
            btnMoveNodeUp.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnMoveNodeUp.Location = new Point(179, 3);
            btnMoveNodeUp.Name = "btnMoveNodeUp";
            btnMoveNodeUp.Size = new Size(87, 30);
            btnMoveNodeUp.TabIndex = 26;
            btnMoveNodeUp.Text = "Up";
            btnMoveNodeUp.UseVisualStyleBackColor = false;
            // 
            // btnMoveNodeDown
            // 
            btnMoveNodeDown.BackColor = SystemColors.Control;
            btnMoveNodeDown.Dock = DockStyle.Right;
            btnMoveNodeDown.Enabled = false;
            btnMoveNodeDown.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnMoveNodeDown.Location = new Point(266, 3);
            btnMoveNodeDown.Name = "btnMoveNodeDown";
            btnMoveNodeDown.Size = new Size(87, 30);
            btnMoveNodeDown.TabIndex = 25;
            btnMoveNodeDown.Text = "Down";
            btnMoveNodeDown.UseVisualStyleBackColor = false;
            // 
            // btnEnableMoveNode
            // 
            btnEnableMoveNode.BackColor = SystemColors.Control;
            btnEnableMoveNode.Dock = DockStyle.Right;
            btnEnableMoveNode.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnableMoveNode.Location = new Point(353, 3);
            btnEnableMoveNode.Name = "btnEnableMoveNode";
            btnEnableMoveNode.Size = new Size(155, 30);
            btnEnableMoveNode.TabIndex = 13;
            btnEnableMoveNode.Text = "위치 변경";
            btnEnableMoveNode.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(pnlFinalNodeEdit);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(571, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20);
            panel2.Size = new Size(647, 850);
            panel2.TabIndex = 1;
            // 
            // pnlFinalNodeEdit
            // 
            pnlFinalNodeEdit.Controls.Add(btnFolderDialog);
            pnlFinalNodeEdit.Controls.Add(lblSelectedNode);
            pnlFinalNodeEdit.Controls.Add(label1);
            pnlFinalNodeEdit.Controls.Add(btnSaveNodePath);
            pnlFinalNodeEdit.Controls.Add(txbNodePath);
            pnlFinalNodeEdit.Dock = DockStyle.Fill;
            pnlFinalNodeEdit.Location = new Point(20, 20);
            pnlFinalNodeEdit.Name = "pnlFinalNodeEdit";
            pnlFinalNodeEdit.Size = new Size(607, 810);
            pnlFinalNodeEdit.TabIndex = 0;
            // 
            // btnFolderDialog
            // 
            btnFolderDialog.Location = new Point(19, 118);
            btnFolderDialog.Name = "btnFolderDialog";
            btnFolderDialog.Size = new Size(104, 33);
            btnFolderDialog.TabIndex = 50;
            btnFolderDialog.Text = "탐색창";
            btnFolderDialog.UseVisualStyleBackColor = true;
            // 
            // lblSelectedNode
            // 
            lblSelectedNode.BorderStyle = BorderStyle.FixedSingle;
            lblSelectedNode.Location = new Point(51, 283);
            lblSelectedNode.Margin = new Padding(0);
            lblSelectedNode.Name = "lblSelectedNode";
            lblSelectedNode.Size = new Size(505, 36);
            lblSelectedNode.TabIndex = 19;
            lblSelectedNode.Text = "선택 노드 :";
            lblSelectedNode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 16);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 49;
            label1.Text = "경로";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSaveNodePath
            // 
            btnSaveNodePath.Location = new Point(487, 118);
            btnSaveNodePath.Name = "btnSaveNodePath";
            btnSaveNodePath.Size = new Size(104, 33);
            btnSaveNodePath.TabIndex = 48;
            btnSaveNodePath.Text = "저장";
            btnSaveNodePath.UseVisualStyleBackColor = true;
            // 
            // txbNodePath
            // 
            txbNodePath.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNodePath.Location = new Point(19, 40);
            txbNodePath.Multiline = true;
            txbNodePath.Name = "txbNodePath";
            txbNodePath.ScrollBars = ScrollBars.Vertical;
            txbNodePath.Size = new Size(572, 72);
            txbNodePath.TabIndex = 47;
            // 
            // DocumentViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DocumentViewControl";
            Size = new Size(1218, 850);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pnlFinalNodeEdit.ResumeLayout(false);
            pnlFinalNodeEdit.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel pnlFinalNodeEdit;
        private TextBox txbNodePath;
        private Button btnSaveNodePath;
        private Label label1;
        private Label lblSelectedNode;
        private TreeView treeView1;
        private Panel panel6;
        private TextBox txbNodeText;
        private Panel panel5;
        private Button btnAddRootNode;
        private Button btnAddNode;
        private Button btnEditNode;
        private Button btnDeleteNode;
        private Panel panel4;
        private Button btnEnableMoveNode;
        private Button btnMoveNodePre;
        private Button btnMoveNodeNext;
        private Button btnMoveNodeUp;
        private Button btnMoveNodeDown;
        private Button btnFolderDialog;
    }
}
