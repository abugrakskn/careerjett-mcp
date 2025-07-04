const express = require('express');
const axios = require('axios');
const app = express();
app.use(express.json());

app.post('/searchJobs', async (req, res) => {
  const { position, city } = req.body;
  try {
    const response = await axios.post('https://public.api.careerjet.net/search', {
      keywords: position,
      location: city,
      locale_code: 'en_TR'
    });
    res.json(response.data);
  } catch (e) {
    res.status(500).json({ error: 'API call failed' });
  }
});

const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Server running on port ${port}`));
