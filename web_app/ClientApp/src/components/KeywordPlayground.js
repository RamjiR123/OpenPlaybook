import React, { useState } from "react";

function KeywordPlayground() {
  //user text box
  const [query, setQuery] = useState("");

  //keyword vector result from backend
  const [vector, setVector] = useState([]);

  //status msg (just basic feedback)
  const [status, setStatus] = useState("");

  //calls POST /api/keywords/extract with {query: "..."}
  const handleExtract = async (e) => {
    e.preventDefault();

    //reset stuff before request
    setStatus("...working");
    setVector([]);

    try {
      const res = await fetch("/api/keywords/extract", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ query }),
      });

      if (!res.ok) {
        setStatus("server error");
        return;
      }

      const data = await res.json();

      //data.vector should be list of strings
      setVector(data.vector || []);
      setStatus("done");
    } catch (err) {
      console.error(err);
      setStatus("network error");
    }
  };

  return (
    <div className="mt-4">
      <h2>Keyword Playground</h2>
      <p className="text-muted">
        type a postseason-style question and we&apos;ll try to pull the
        important words / years out of it. this mirrors backend logic.
      </p>

      <form onSubmit={handleExtract} className="mb-3">
        <div className="mb-3">
          <label className="form-label">
            your query (ex: "who won the alcs in 2018 and the world series?")
          </label>
          <textarea
            className="form-control"
            rows={3}
            value={query}
            onChange={(e) => setQuery(e.target.value)}
            placeholder='who won the alcs in 2018 and the world series?'
          />
        </div>

        <button type="submit" className="btn btn-primary">
          extract keywords
        </button>
      </form>

      <div className="mb-2">
        <strong>status:</strong> {status || "idle"}
      </div>

      <div>
        <strong>vector:</strong>{" "}
        {vector.length === 0 ? (
          <span>[ ]</span>
        ) : (
          <code>[ {vector.join(", ")} ]</code>
        )}
      </div>
    </div>
  );
}

export default KeywordPlayground;
