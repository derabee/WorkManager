using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
using SG_WorkManager;
using SG_WorkManager.Item;
using SG_WorkManager.Manager;
using SG_WorkManager.ViewControl.ViewInterface;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SG_WorkManager
{

    public partial class DocumentViewControl : UserControl, IViewControl
    {
        NetworkConnector share1 = new NetworkConnector();
        FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
        public bool IsSaved { get; set; } = true;
        public string ControlName { get; set; }
        public string DisplayText { get; set; }
        public int PageNumber { get; set; }
        public DocumentViewControl()
        {
            InitializeComponent();
            this.IsSaved = true;
            CreateDefaultFolder();
            InitEvent();
            InitData();
            ShowNodePathEdit(false);
            //treeView1.ExpandAll();
        }

        private Dictionary<string, string> _dictNodePath = new Dictionary<string, string>();

        private TreeNode _selectedNode;
        private TreeNode _sourceNode;

        private bool _isEnableMoveNode;



        private string GetDefaultPath()
        {
            return $@"{Settings.DEFAULT_PATH}\{Settings.DOCUMENT_PATH}";
        }

        private void CreateDefaultFolder()
        {
            var defaultPath = GetDefaultPath();
            if (Directory.Exists(defaultPath) == false)
            {
                Directory.CreateDirectory(defaultPath);
            }
        }

        private Font selectedNodeFont = new Font("맑은 고딕", 9, FontStyle.Underline);
        private Font unSelectedNodeFont = new Font("맑은 고딕", 9, FontStyle.Regular);

        private TreeNode GetNewNode()
        {
            var node = new TreeNode("New Node");
            node.Tag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return node;
        }
        private void InitEvent()
        {
            treeView1.NodeMouseClick += (sender, e) =>
            {
                var selectedNode = e.Node;
                treeView1.SelectedNode = selectedNode;
                selectedNode.NodeFont = selectedNodeFont;
                selectedNode.ForeColor = Color.Blue;
                if (_selectedNode != null)
                {
                    _selectedNode.NodeFont = unSelectedNodeFont;
                    _selectedNode.ForeColor = Color.Black;
                }
                SetSelectedNode(treeView1.SelectedNode);
                var isFinalNode = selectedNode.Nodes.Count == 0;
                ShowNodePathEdit(isFinalNode);
            };

            treeView1.NodeMouseDoubleClick += (sender, e) =>
            {
                var selectedNode = treeView1.SelectedNode;
                SetSelectedNode(treeView1.SelectedNode);
                var isFinalNode = selectedNode.Nodes.Count == 0;
                if (isFinalNode)
                {
                    var path = GetSelectedNodePath();
                    txbNodePath.Text = path;
                    OpenNetworkDirectory(path);
                }
            };

            btnSaveNodePath.Click += delegate
            {
                SaveNodePath();
            };

            btnAddRootNode.Click += delegate
            {
                var node = GetNewNode();
                treeView1.Nodes.Add(node);
                treeView1.SelectedNode = node;
                SaveTreeNode();
            };

            btnAddNode.Click += delegate
            {
                var node = GetNewNode();
                if (_selectedNode == null)
                {
                    treeView1.Nodes.Add(node);
                    treeView1.SelectedNode = node; 
                }
                else
                {
                    _selectedNode.Nodes.Add(node);
                    treeView1.SelectedNode = node; 
                    ShowNodePathEdit(false);
                }
                SaveTreeNode();
            };

            btnEditNode.Click += delegate
            {
                EditNode();
            };

            btnDeleteNode.Click += delegate
            {
                if (DialogResult.Yes == MessageBox.Show("정말로 삭제하시겠습니까?\r\n하위 노드까지 모두 삭제됩니다.","노드 삭제",MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
                {
                    RemoveNodePath(GetNodeKey(_selectedNode));
                    RemoveNode(_selectedNode);
                
                    ShowNodePathEdit(false);
                    _selectedNode = null;
                    txbNodeText.Text = string.Empty;
                    SaveTreeNode();
                    MessageBox.Show("노드 삭제 완료");
                }
            };

            txbNodeText.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(_selectedNode != null)
                    {
                        if (_selectedNode.Text == txbNodeText.Text)
                        {
                            
                            OpenNetworkDirectory(GetSelectedNodePath());
                        }
                        else
                        {
                            EditNode();
                        }
                    }
                    e.Handled = true;
                }
            };

            treeView1.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (_selectedNode != null)
                    {
                        if (_selectedNode.Text == txbNodeText.Text)
                        {

                            OpenNetworkDirectory(GetSelectedNodePath());
                        }
                        else
                        {
                            EditNode();
                        }
                    }
                    e.Handled = true;
                }
            };

            txbNodePath.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txbNodePath.Text != string.Empty)
                    { 
                        if (GetSelectedNodePath() == txbNodePath.Text)
                        {
                            OpenNetworkDirectory(GetSelectedNodePath());
                        }
                        else
                        {
                            SaveNodePath();
                        }
                    }
                    e.SuppressKeyPress = true;
                }
            };

            treeView1.ItemDrag += (sender, e) =>
            {
                _sourceNode = (TreeNode)e.Item;
                DoDragDrop(e.Item.ToString(), DragDropEffects.Move | DragDropEffects.Copy);
            };

            // Define the event that occurs while the dragging happens
            treeView1.DragEnter += (sender, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.Text))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;

            };

            // Determine what node in the tree we are dropping on to (target),
            // copy the drag source (_sourceNode), make the new node and delete
            // the old one.
            treeView1.DragDrop += (sender, e) =>
            {
                Point pos = treeView1.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = treeView1.GetNodeAt(pos);
                TreeNode nodeCopy;

                if (targetNode != null)
                {
                    nodeCopy = new TreeNode(_sourceNode.Text, _sourceNode.ImageIndex, _sourceNode.SelectedImageIndex);

                    if (targetNode.Parent != null)
                    {
                        if (_sourceNode.Index > targetNode.Index)
                            targetNode.Parent.Nodes.Insert(targetNode.Index, nodeCopy);
                        else
                            targetNode.Parent.Nodes.Insert(targetNode.Index + 1, nodeCopy);
                    }
                    else
                    {
                        if (_sourceNode.Index > targetNode.Index)
                            treeView1.Nodes.Insert(targetNode.Index, nodeCopy);
                        else
                            treeView1.Nodes.Insert(targetNode.Index + 1, nodeCopy);
                    }
                    _sourceNode.Remove();
                    treeView1.Invalidate();
                }
                
            };

            this.ParentChanged += (sender, e) =>
            { 
                if(this.Parent == null)
                    SaveTreeNode();
            };

            btnMoveNodePre.Click += delegate
            {
                var node = _selectedNode;
                if (node == null)
                    return;

                var preNode = node.PrevNode;
                if (preNode == null)
                    return;
                ExchangeNodePath(node, preNode);
            };

            btnMoveNodeNext.Click += delegate
            {
                var node = _selectedNode;
                if (node == null)
                    return;

                var nNode = node.NextNode;
                if (nNode == null)
                    return;

                ExchangeNodePath(node, nNode);
            };

            btnMoveNodeUp.Click += delegate
            {
                var node = _selectedNode;
                if (node == null)
                    return;

                var pNode = node.Parent;
                if (pNode == null)
                    return;

                var ppNode = pNode.Parent;

                var cloneNode = node.Clone() as TreeNode;
                var nodes = ppNode == null ? treeView1.Nodes : ppNode.Nodes;
                if (pNode.Index >= nodes.Count - 1)
                {
                    nodes.Add(cloneNode);
                }
                else
                {
                    nodes.Insert(pNode.Index + 1, cloneNode);       
                }
                node.Remove();
                treeView1.SelectedNode = cloneNode;
                _selectedNode = cloneNode;

            };

            btnMoveNodeDown.Click += delegate
            {
                var node = _selectedNode;
                if (node == null)
                    return;

                var preNode = node.PrevNode;
                if (preNode == null)
                    return;
                var cloneNode = node.Clone() as TreeNode;

                preNode.Nodes.Add(cloneNode);

                node.Remove();
                treeView1.SelectedNode = cloneNode;
                _selectedNode = cloneNode;
            };

            btnEnableMoveNode.Click += delegate
            {
                if(_selectedNode != null)
                    EneableMoveNode(_isEnableMoveNode = !_isEnableMoveNode);
            };

            btnFolderDialog.Click += delegate
            {
                var dialog = _folderBrowserDialog;
                dialog.Description = "Select a folder :";
                dialog.ShowNewFolderButton = true;
                //dialog.InitialDirectory = $"{txbNodePath.Text}\\";
                dialog.SelectedPath = $"{txbNodePath.Text}\\";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txbNodePath.Text = $"{dialog.SelectedPath}";
                }
            };
        }

        private void ExchangeNodePath(TreeNode sNode, TreeNode tNode)
        {
            var cloneNode = sNode.Clone() as TreeNode;

            if (tNode.Parent == null)
            {
                treeView1.Nodes[tNode.Index] = cloneNode;
                treeView1.Nodes[sNode.Index] = tNode;
            }
            else
            {
                sNode.Parent.Nodes[tNode.Index] = cloneNode;
                sNode.Parent.Nodes[sNode.Index] = tNode;
            }
            treeView1.SelectedNode = cloneNode;
            _selectedNode = cloneNode;
        }

        private void EneableMoveNode(bool isEnableMoveNode)
        {
            btnMoveNodeNext.Enabled = isEnableMoveNode;
            btnMoveNodePre.Enabled = isEnableMoveNode;
            btnMoveNodeUp.Enabled = isEnableMoveNode;
            btnMoveNodeDown.Enabled = isEnableMoveNode;
            /*
            var colorEnabled = Color.SpringGreen;
            var colorDisabled = Color.DimGray;
            btnMoveNodeNext.BackColor = isEnableMoveNode ? colorEnabled : colorDisabled;
            btnMoveNodePre.BackColor = isEnableMoveNode ? colorEnabled : colorDisabled;
            btnMoveNodeUp.BackColor = isEnableMoveNode ? colorEnabled : colorDisabled;
            btnMoveNodeDown.BackColor = isEnableMoveNode ? colorEnabled : colorDisabled;
            */
            btnAddRootNode.Enabled = !isEnableMoveNode;
            btnAddNode.Enabled = !isEnableMoveNode;
            btnEditNode.Enabled = !isEnableMoveNode;
            btnDeleteNode.Enabled = !isEnableMoveNode;
            txbNodeText.Enabled = !isEnableMoveNode;
            txbNodePath.Enabled = !isEnableMoveNode;
            btnSaveNodePath.Enabled = !isEnableMoveNode;
            treeView1.Enabled = !isEnableMoveNode;
            btnEnableMoveNode.Text = isEnableMoveNode ? "변경 사항 저장" : "위치 변경";
            if (!isEnableMoveNode)          
                SaveTreeNode();
        }

        private string GetSelectedNodePath()
        {
            if (_selectedNode == null)
            {
                return string.Empty;
            }
            else
            {
                return GetNodePath(GetNodeKey(_selectedNode));
            }
        }

        private void RemoveNode(TreeNode node)
        {
            if (node != null)
                node.Remove();
            /* for (int i = 0, count = treeNodes.Count; i < count; i++)
            {
                if (treeNodes.Contains(node))
                {
                    treeNodes.Remove(node);
                    break;
                }
                else
                {
                    if (treeNodes[i].Nodes.Count != 0)
                    {
                        RemoveNode(treeNodes[i].Nodes, node);
                    }
                }
            }*/
        }

        private void SetSelectedNode(TreeNode selectedNode)
        {
            _selectedNode = selectedNode;
            lblSelectedNode.Text = $"선택 노드 : {selectedNode?.Text ?? string.Empty}";
            txbNodeText.Text = selectedNode?.Text ?? string.Empty;
        }

        private void EditNode()
        {
            if (_selectedNode != null)
            {
                _selectedNode.Text = txbNodeText.Text;
                //ShowNodePathEdit(true);
                SaveTreeNode();
                MessageBox.Show("노드 이름 변경 완료");
            }
        }

        private void AddNodes(TreeNodeCollection treeNodes, List<Node> nodes)
        {
            for (int i = 0, count = nodes.Count; i < count; i++)
            {
                var node = treeNodes.Add(nodes[i].Text);
                if (nodes[i].IsExpanded)
                    node.Expand();
                node.Tag = nodes[i].Key;
                AddNodes(treeNodes[i].Nodes, nodes[i].Children);
            }
        }

        // 수정 필요
        private void InitData()
        {
            // Node -> TreeView NodeCollection
            
            treeView1.Nodes.Clear();
            var fileName = GetTreeNodeFileName();
            if (File.Exists(fileName))
            {
                using FileStream openStream = File.OpenRead(fileName);
                var nodes = JsonSerializer.DeserializeAsync<Node>(openStream).Result;
                AddNodes(treeView1.Nodes, nodes.Children);
                /*for (int i = 0, count = nodes.Children.Count; i < count; i++)
                {
                    treeView1.Nodes.Add(nodes.Children[i].Text);
                    for(int j = 0, count2 = nodes.Children[i].Children.Count; j < count2; j++)
                    {
                        treeView1.Nodes[i].Nodes.Add(nodes.Children[i].Children[j].Text);
                    }
                }*/
            }

            var fileName2 = GetNodePathFileName();
            if (File.Exists(fileName2))
            {
                using FileStream openStream = File.OpenRead(fileName2);
                _dictNodePath = JsonSerializer.DeserializeAsync<Dictionary<string, string>>(openStream).Result;
            }
            
        }

        private void ShowNodePathEdit(bool isFinalNode)
        {
            if (isFinalNode)
            {
                txbNodePath.Text = GetNodePath(GetNodeKey(_selectedNode));
            }
            pnlFinalNodeEdit.Visible = isFinalNode;
        }

        private string GetNodePath(string nodeKey)
        {
            if (_dictNodePath.TryGetValue(nodeKey, out var path)) 
            { 
                return path; 
            }
            else
            {
                return string.Empty;
            }
        }

        private void AddNodePath(string nodeKey, string path)
        {
            if (_dictNodePath.ContainsKey(nodeKey))
            {
                _dictNodePath[nodeKey] = path;
            }
            else
            {
                _dictNodePath.Add(nodeKey, path);
            }
        }

        private void RemoveNodePath(string nodeKey)
        {
            _dictNodePath.Remove(nodeKey);
        }

        // 구현 필요
        private void OpenNetworkDirectory(string path)
        {
            try
            {
                /*
                var fileName = GetOpenNetworkFolerFilePath();
                if (!File.Exists(fileName))
                {
                    var text = @"start {path}";

                    StreamWriter file = new StreamWriter(fileName);
                    file.Write(text);
                    file.Close();
                }
                System.Diagnostics.Process pros = new System.Diagnostics.Process();
                pros.StartInfo.FileName = fileName;
                pros.StartInfo.WorkingDirectory = GetDefaultPath();
                pros.Start();
                */
                if (!Directory.Exists(path))
                {
                    MessageBox.Show($"해당 폴더가 존재하지 않습니다.\r\n{path}");
                }
                Process.Start("explorer.exe", $"\"{path}\"");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetOpenNetworkFolerFilePath()
        {
            const string FILE_EXTENTION = "bat";
            var fileName = $@"{GetNodePathDefaultPath()}\{Settings.OPEN_NETWORK_FOLDER_FILE_NAME}.{FILE_EXTENTION}";
            return fileName;
        }

        private void AddNodesMToV(List<Node> nodes, TreeNodeCollection treeNodes)
        {
            for(int i = 0, count = treeNodes.Count; i < count; i++)
            {
                var node = treeNodes[i];
                nodes.Add(new Node() { Text = node.Text, IsExpanded = node.IsExpanded, Key = node.Tag.ToString() });
                AddNodesMToV(nodes[i].Children, treeNodes[i].Nodes);
            }
        }

        // 수정 필요
        private async void SaveTreeNode()
        { 
            var fileName = GetTreeNodeFileName();
            var masterNode = new Node();
            // TreeView NodeCollection -> Node
            AddNodesMToV(masterNode.Children, treeView1.Nodes);       

            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, masterNode);
        }

        private async void SaveNodePath()
        {
            AddNodePath(GetNodeKey(_selectedNode), txbNodePath.Text);
            var fileName = GetNodePathFileName();
            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, _dictNodePath);
            MessageBox.Show("경로 저장 완료");
        }

        private string GetNodeKey(TreeNode node)
        {
            return node?.Tag.ToString() ?? string.Empty;
        }

        private string GetNodePathDefaultPath()
        {
            return $@"{Settings.DEFAULT_PATH}\{Settings.DOCUMENT_PATH}";
        }

        private string GetNodePathFileName()
        {
            const string FILE_EXTENTION = "json";
            var fileName = $@"{GetNodePathDefaultPath()}\{Settings.NODEPATH_FILE_NAME}.{FILE_EXTENTION}";
            return fileName;
        }

        private string GetTreeNodeFileName()
        {
            const string FILE_EXTENTION = "json";
            var fileName = $@"{GetNodePathDefaultPath()}\{Settings.TREENODE_FILE_NAME}.{FILE_EXTENTION}";
            return fileName;
        }

        public bool Save()
        {
            return true;
        }

        private static DocumentViewControl s_instance;
        public static DocumentViewControl GetInstance()
        {
            if (s_instance == null || s_instance.IsDisposed)
                s_instance = new DocumentViewControl();

            return s_instance;
        }

        public bool CanProcess()
        {
            return true;
        }
    }

}
