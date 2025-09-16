# OpenPlaybook

OpenPlaybook is an open-source sports analytics platform that enables **semantic search and exploration of play-by-play data**. Unlike traditional box scores and rigid filters, OpenPlaybook lets coaches, analysts, and fans discover nuanced game dynamics through **natural language queries and intuitive visualizations**.

---

## 📌 Problem Statement
Most existing sports analytics tools rely heavily on structured statistics and rigid filters, making it difficult to explore the true flow of a game. For example:
- Box scores show how many points a player scored, but not **how** those points were created.
- Play-by-play logs exist, but they’re trapped in text or numbers, making it nearly impossible to query for patterns like:
  - *“Fast breaks after turnovers”*
  - *“Defensive collapses leading to corner threes”*

The missing piece is a **semantic layer** that allows natural language discovery of plays, unlocking deeper insights for both casual fans and professional analysts.

---

## 🎯 Overview and Goals
OpenPlaybook bridges the gap between raw data and meaningful narratives by combining play-by-play logs with **modern NLP and vector search techniques**.  

With OpenPlaybook, users can:
- Ask questions like:
  - *“Show me all basketball plays where the defense collapsed and led to a corner three.”*  
  - *“Find soccer counterattacks that started within 10 seconds of a turnover.”*
- Explore results through a clean, web-based interface with filtering and visualization.
- Gain deeper context on plays, players, and game dynamics.

### Project Goals
By the end of the semester, the project aims to deliver a **full-stack web app** with:
- Natural language search of play-by-play data
- Play metadata display (time, players, outcome, etc.)
- Interactive filtering (by game, team, player, quarter/period)
- Visualization features for sports plays
- Optional: player tracking and achievements using computer vision

---

## 🚀 Features
- **Data Ingestion**
  - Collect play-by-play data from public/free sources
  - Normalize into a consistent backend schema
  - Store processed data in a database  

- **Embedding & Storage**
  - Generate embeddings for each play description
  - Store embeddings in a vector database (Qdrant/Weaviate)
  - Support similarity search (top-k by cosine similarity)  

- **Search API**
  - Accept natural language queries
  - Convert queries into embeddings and return most relevant plays
  - Include metadata + relevance scores  

- **Web Application**
  - Search bar for natural language queries
  - Results display with play descriptions & metadata
  - Filters by team, player, game, and quarter/period  

- **Computer Vision / Machine Learning**
  - Object detection for advanced insights
  - Track player performance: shots, passes, turnovers
  - Video-based play analysis  

- **MCP Agent Integration (Optional)**
  - Expose the semantic API as an MCP tool
  - Allow LLMs to query play-by-play data directly  

---

## ⚙️ Tech Stack

### Backend
- **C# + ASP.NET Core Web API**

### Frontend/UI
- **Next.js (React + TypeScript)**
- **TailwindCSS** for styling
- **Recharts** or **D3.js** for play visualizations
- Authentication: **Clerk.js** or **NextAuth.js**

### Database Layer
- **PostgreSQL** → structured player/game data
- **Vector DB**: Qdrant (lightweight, Docker-ready) or Weaviate (hybrid keyword + semantic)
- ORM: Prisma (Node.js) or Entity Framework Core (.NET)

### NLP / LLM
- **LangChain (Python)**
- **Sentence Transformers / Hugging Face models** → play embeddings
- **Ollama (local)** → small LLMs
- **YOLOv10 / YOLOv12** → object detection for computer vision

### DevOps & Tools
- **Docker** for containerization
- **GitHub** for version control
- Deployment: **Railway** or **Render**
- **Supabase** (if hosted Postgres + auth is needed)

---

## 📊 Example Use Cases
- “Find all basketball plays where the defense collapsed and led to a corner three.”
- “Show me soccer counterattacks that started within 10 seconds of a turnover.”
- “Which player had the most successful passes leading to shots on goal?”

---

## 🛠️ Setup (Coming Soon)
Detailed installation and setup instructions will be added as the project progresses.

---

## 🤝 Contributing
We welcome contributions from the community!  
Ideas, bug reports, and pull requests are all encouraged to help shape **OpenPlaybook** into the go-to semantic sports analytics platform.

---

## 📜 License
MIT License – free to use, modify, and distribute.

---
